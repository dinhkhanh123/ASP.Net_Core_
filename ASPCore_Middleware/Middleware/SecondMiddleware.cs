using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class SecondMiddleware : IMiddleware
{
    /* Url : "/abc.html"
    - ko goi middleware phia sau
    -ban ko dc truy cap
    - Header - SecondMiddleware : ban khong duoc truy cap

    url : != "/abc.html"
    - Header - SecondMiddleware : ban duoc truy cap
    - chuyen den httpcontext cho middleware phia sau
    
    **/
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.Request.Path == "/abc.html")
        {
            context.Response.Headers.Add("SecondMiddleware", "ban khong duoc truy cap");
            var dataFromFirstMiddleware = context.Items["DataFirstMiddleware"];
            if (dataFromFirstMiddleware != null)
                await context.Response.WriteAsync((string)dataFromFirstMiddleware);

            await context.Response.WriteAsync(" \n Ban ko duoc truy cap");
        }
        else
        {
            context.Response.Headers.Add("SecondMiddleware", "ban duoc truy cap");
            var dataFromFirstMiddleware = context.Items["DataFirstMiddleware"];
            if (dataFromFirstMiddleware != null)
                await context.Response.WriteAsync((string)dataFromFirstMiddleware);
            await next(context);
        }
    }
}