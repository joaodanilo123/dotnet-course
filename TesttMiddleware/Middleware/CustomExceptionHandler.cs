
namespace TesttMiddleware.Middleware
{
    public class CustomExceptionHandler : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
			{
                await next(context);
            }
			catch (Exception e)
            {
                context.Response.StatusCode = 500;
                Console.WriteLine(e.Message);
                await context.Response.WriteAsync("<h1>Internal Server Error</h1>");
                await context.Response.WriteAsync($"<p>{e.Message}</p>");
            }
        }
    }
}
