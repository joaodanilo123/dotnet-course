using WebApp.Controller;

namespace WebApp.Infrastructure;

public class ControllerRegistry
{
    public readonly Dictionary<string, Type> _controllers = new();
    public void RegisterController<T>(string basePath) where T : BaseController
    {
        _controllers[basePath] = typeof(T);
    }
    public BaseController? GetController(HttpContext context)
    {
        var path = context.Request.Path.Value;
        if (path is null || !_controllers.ContainsKey(path))
        {
            return null;
        }

        var controllerType = _controllers[path];

        return (BaseController?)Activator.CreateInstance(controllerType, context, path);
    }
}
