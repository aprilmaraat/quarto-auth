using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Quarto.Auth.Api;

namespace Quarto.Auth.Test
{
    [TestClass]
    public class GlobalTest
    {
        public static TestServer Server { get; private set; }

        [AssemblyInitialize]
        public static void Init(TestContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            
            Server = new TestServer(new WebHostBuilder()
                                        .ConfigureAppConfiguration(c => c.AddUserSecrets<Startup>())
                                        .UseStartup<Startup>());
        }
    }
}
