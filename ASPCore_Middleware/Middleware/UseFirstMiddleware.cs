using Microsoft.AspNetCore.Builder;

public static class UseFirstMiddlewareMethod
{
    public static void UseFirstMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<FirstMiddleware>();
    }

    public static void SecondFirstMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<SecondMiddleware>();
    }
}