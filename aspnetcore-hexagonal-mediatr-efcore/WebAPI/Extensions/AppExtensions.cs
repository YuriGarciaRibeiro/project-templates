using WebAPI.Middleware;

namespace WebAPI.Extensions;

public static class AppExtensions
{
    public static WebApplication UseMiddlewares(this WebApplication app)
    {
        // ADD YOUR MIDDLEWARE HERE
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        return app;
    }    
}