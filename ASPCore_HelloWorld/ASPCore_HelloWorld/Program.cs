using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ASPCore_HelloWorld
{
    public class Program
    {
        // public static void Main(string[] args)
        // {
        //     Console.WriteLine("Start App");
        //     IHostBuilder builder = Host.CreateDefaultBuilder(args);
        //     //cau hinh mac dinh cho host tao ra
        //     builder.ConfigureWebHostDefaults((IWebHostBuilder webBuilder) =>
        //     {
        //         // tuy bien ve host
        //         //webBuilder.
        //         webBuilder.UseWebRoot("public");
        //         webBuilder.UseStartup<MyStartup>();


        //     });
        //     IHost host = builder.Build();
        //     host.Run();

        // }


        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseStartup<MyStartup>();
               });
    }
}
