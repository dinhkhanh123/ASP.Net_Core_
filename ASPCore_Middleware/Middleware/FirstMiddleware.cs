
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class FirstMiddleware
{
    private readonly RequestDelegate _next;
    // RequestDelegate ~ async HTTPContext (context)
    public FirstMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    //Http Context di qua middleware trong pipeline 
    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine(context.Request.Path);
        context.Items.Add("DataFirstMiddleware", $"URL: {context.Request.Path}");
        //await context.Response.WriteAsync($"URL: {context.Request.Path}");
        await _next(context);
    }
}