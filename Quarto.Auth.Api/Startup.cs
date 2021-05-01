using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quarto.Auth.EF;
using Microsoft.EntityFrameworkCore;
using Quarto.Auth.Services;
using Quarto.Auth.Singleton;
using Quarto.Common.Package;

namespace Quarto.Auth
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            IConfigurationBuilder builder = GetConfigurationBuilder(environment);
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            QuartoAuth authCache = Configuration.GetSection("Quarto").Get<QuartoAuth>();
            services.AddDbContext<AuthContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Master")));
            services.AddTransient<ITokenService, TokenService>();
            services.AddSingleton<IAppCache>(authCache);
            services.AddControllers();
            services.AddCors();
        }

        private IConfigurationBuilder GetConfigurationBuilder(IWebHostEnvironment env)
        {
            return new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                //.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddUserSecrets<Startup>()
                .AddEnvironmentVariables();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(t => t.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
