namespace WebApp.Controller;

public abstract class BaseController
{

    public string BasePath { get; init; }

    private readonly Dictionary<string, Func<HttpContext, Task>> _handlers = new();

    protected readonly HttpContext _context;
    public BaseController(HttpContext context, string basePath)
    {
        _context = context;
        BasePath = basePath;
    }

    protected void RegisterHandler(string method, Func<HttpContext, Task> handler)
    {
        _handlers[method.ToUpperInvariant()] = handler;
    }

    public async Task HandleRequestAsync()
    {
        var method = _context.Request.Method.ToUpperInvariant();
        if (_handlers.TryGetValue(method, out var handler))
        {
            await handler(_context);
        }
        else
        {
            _context.Response.StatusCode = 405;
            await _context.Response.WriteAsync("Method not allowed.");
        }
    }

}


