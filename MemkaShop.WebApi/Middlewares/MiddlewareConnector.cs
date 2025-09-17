namespace MemkaShop.WebApi.Middlewares;

public static class MiddlewareConnector
{
    public static IApplicationBuilder UseMiddlewares(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        
        return app;
    }
}