using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ASPCore_Middleware
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<SecondMiddleware>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseStaticFiles(); //StaticFilesMiddleware

            // app.UseMiddleware<FirstMiddleware>();
            app.UseFirstMiddleware();// Dua vao pipeline FirstMiddleware

            //app.UseMiddleware<SecondMiddleware>();
            app.SecondFirstMiddleware();//Dua vao pipeline SecondMiddleware

            app.UseRouting();

            //EndpointMiddleware
            app.UseEndpoints((endpoint) =>
                      {
                          //E1
                          endpoint.MapGet("/about.html", async (context) =>
                          {
                              await context.Response.WriteAsync("\n This is page About");
                          });

                          //E2
                          endpoint.MapGet("/product.html", async (context) =>
                         {
                             await context.Response.WriteAsync("\n This is page Product");
                         });
                      });


            // Re nhanh pipeline
            app.Map("/admin", (app1) =>
            {
                app1.UseRouting();

                //EndpointMiddleware
                app1.UseEndpoints((endpoint) =>
                          {
                              //E1
                              endpoint.MapGet("/user", async (context) =>
                              {
                                  await context.Response.WriteAsync("\n Quan ly nguoi dung");
                              });

                              //E2
                              endpoint.MapGet("/product", async (context) =>
                             {
                                 await context.Response.WriteAsync("\n Quan ly san pham");
                             });
                          });

                app1.Run(async (context) =>
                {
                    await context.Response.WriteAsync("\n Trang Admin");
                });
            });


            //Terminal middleware M1
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("\n Hello ASP core web");
            });
        }
    }
}
/*  

pipeline :StaticFilesMiddleware
            -FirstMiddleware
            -SecondMiddleware
            - EndpointMiddleware
             -FirstMiddleware M1
**/ 