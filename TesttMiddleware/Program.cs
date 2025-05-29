using TesttMiddleware.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<CustomExceptionHandler>();

var app = builder.Build();

app.UseMiddleware<CustomExceptionHandler>();

app.MapWhen((ctx) => ctx.Request.Path.StartsWithSegments("/employees"), (appBuilder) =>
{
    appBuilder.Use(async (HttpContext context, RequestDelegate next) =>
    {
        if(context.Request.Query.ContainsKey("id"))
        {
            var parsed = int.TryParse(context.Request.Query["id"], out int id);
            if(parsed)
            {
                context.Response.StatusCode = 200;
                await context.Response.WriteAsync($"<p>User with Id {id}</p>");
            } else
            {
                throw new ArgumentException("Invalid value for param id");
            }

            return;
        }

        throw new ArgumentException("Param id not found");

    });
});

app.Run();
