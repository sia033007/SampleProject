namespace Person.MVC
{
    public class CustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Fuck You!");
            await next(context);
        }
    }
}
