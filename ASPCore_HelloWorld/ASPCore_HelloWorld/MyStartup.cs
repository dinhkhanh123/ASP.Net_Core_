
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class MyStartup
{
    //dang ky cac dich vu ung dung
    public void ConfigureServices(IServiceCollection services)
    {

    }
    // xay dung pipeline (chuoi midd)
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        //StaticFileMiddleware
        // wwwroot
        app.UseStaticFiles();

        //EndpointRouting Middleware
        app.UseRouting();
        // truy cap GET = / => diem cuoi nay thi hanh
        app.UseEndpoints(endpoint =>
        {
            endpoint.MapGet("/", async (context) =>
            {
                //npm (nodejs)
                string html = @"
                <!DOCTYPE html>
                <html>
                <head>
                    <meta charset=""UTF-8"">
                    <title>Trang web đầu tiên</title>
                    <link rel=""stylesheet"" href=""/css/bootstrap.min.css"" />
                    <script src=""/js/jquery.min.js""></script>
                    <script src=""/js/popper.min.js""></script>
                    <script src=""/js/bootstrap.min.js""></script>


                </head>
                <body>
                    <nav class=""navbar navbar-expand-lg navbar-dark bg-danger"">
                            <a class=""navbar-brand"" href=""#"">Brand-Logo</a>
                            <button class=""navbar-toggler"" type=""button"" data-toggle=""collapse"" data-target=""#my-nav-bar"" aria-controls=""my-nav-bar"" aria-expanded=""false"" aria-label=""Toggle navigation"">
                                    <span class=""navbar-toggler-icon""></span>
                            </button>
                            <div class=""collapse navbar-collapse"" id=""my-nav-bar"">
                            <ul class=""navbar-nav"">
                                <li class=""nav-item active"">
                                    <a class=""nav-link"" href=""#"">Trang chủ</a>
                                </li>
                            
                                <li class=""nav-item"">
                                    <a class=""nav-link"" href=""#"">Học HTML</a>
                                </li>
                            
                                <li class=""nav-item"">
                                    <a class=""nav-link disabled"" href=""#"">Gửi bài</a>
                                </li>
                        </ul>
                        </div>
                    </nav> 
                    <p class=""display-4 text-danger"">Đây là trang đã có Bootstrap</p>
                </body>
                </html>
    ";
                await context.Response.WriteAsync(html);
            });

            endpoint.MapGet("/gioi-thieu", async (context) =>
            {
                await context.Response.WriteAsync("Trang gioi thieu");
            });

            endpoint.MapGet("/lien-he", async (context) =>
            {
                await context.Response.WriteAsync("Trang lien he");
            });
        });


        //terminal middleware M2
        app.Map("/abc", app1 =>
        {
            app1.Run(async (context) =>
            {
                await context.Response.WriteAsync("Xin chao day la app1 abc");
            });
        });

        //terminal middleware M1
        // app.Run(async (HttpContext context) =>
        // {
        //     await context.Response.WriteAsync("Xin chao day la MyStratup");
        // });

        //UseStatusCodePages M1
        app.UseStatusCodePages();

    }
}