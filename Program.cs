using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MyWebsite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Output("Application - Start");
            var webHost = CreateHostBuilder(args).Build();
            Output("Run WebHost");
            webHost.Run();
            //Run後才會到Configure
            Output("Application - End");
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            Output("Create WebHost Builder");

            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices(services =>
                    {
                        Output("webHostBuilder.ConfigureServices - Called");
                    }).Configure(app =>
                    {
                        Output("webHostBuilder.Configure - Called");
                    }).UseStartup<Startup>();

                    Output("Build WebHost");
                });
        }


        public static void Output(string message)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}] {message}");
        }
    }
}
