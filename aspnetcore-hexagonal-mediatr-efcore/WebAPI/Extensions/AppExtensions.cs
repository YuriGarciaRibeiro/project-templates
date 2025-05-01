using Prometheus;
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

    public static WebApplication UserMetrics(this WebApplication app)
    {
        app.MapMetrics(); // expõe em /metrics
        app.MapGet("/", () => "API Online");
        return app;
    }
}