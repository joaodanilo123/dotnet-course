using WebApp.Controller;
using WebApp.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext ctx) =>
{

    var controllerRegistry = new ControllerRegistry();
    controllerRegistry.RegisterController<EmployeeController>("/employee");

    var controller = controllerRegistry.GetController(ctx);
    if (controller is not null)
    {
        await controller.HandleRequestAsync();
    }
    else
    {
        ctx.Response.StatusCode = 404;
        await ctx.Response.WriteAsync("Controller not found.");
    }
});

app.Run();
