using System.Text.Json;
using WebApp.Repository;

namespace WebApp.Controller;

public class EmployeeController : BaseController
{

    EmployeeRepository employeeRepository = new EmployeeRepository();

    public EmployeeController(HttpContext context, string basePath) : base(context, basePath)
    {
        RegisterHandler("GET", async ctx => await GetEmployeesAsync(ctx));
        RegisterHandler("POST", async ctx => await CreateEmployeeAsync(ctx));
    }

    private async Task GetEmployeesAsync(HttpContext context)
    {
        var employees = employeeRepository.GetAll();
        string json = JsonSerializer.Serialize(employees);
        await context.Response.WriteAsync(json);
    }

    private async Task CreateEmployeeAsync(HttpContext context)
    {
        using var reader = new StreamReader(context.Request.Body);
        var body = await reader.ReadToEndAsync();
        Employee? employee = JsonSerializer.Deserialize<Employee>(body);
        employeeRepository.Add(employee);
        await context.Response.WriteAsync("Employee created successfully.\r\n");
    }
}
