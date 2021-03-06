using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ProductionMonitoring.WebHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    var appSelector = Environment.GetEnvironmentVariable("APP")?.ToUpper();

                    switch (appSelector)
                    {
                        case "MEASURE":
                            webBuilder.UseStartup<MeasureStartup>();
                            break;

                        default:
                            webBuilder.UseStartup<ServerStartup>();
                            break;
                    }
                });
    }
}
