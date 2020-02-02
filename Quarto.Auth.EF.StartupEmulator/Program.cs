using System;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Quarto.Auth.EF.StartupEmulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

//        public class AuthContextFactory : IDesignTimeDbContextFactory<AuthContext> 
//        {
//            private const string migrationOptionsFileName = "MigrationOptions.json";
//            public AuthContext CreateDbContext(string[] args)
//            {
//                if(args == null || args.Length < 1)
//                {
//                    while (!File.Exists(migrationOptionsFileName))
//                    {
//                        Console.WriteLine("Please type in a connection string to your Quarto.Master Database:");
//                        string inputString = Console.ReadLine();
//                        File.WriteAllText(migrationOptionsFileName,
//                            $@"{{
//  ""ConnectionStrings"": {{
//    ""Master"": ""{inputString.Replace("\\", "\\\\").Replace("\"", "\\\"")}""
//  }}
//}}");
//                    }
//                    IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().SetBasePath
//                }
//            }
//        }
    }
}
