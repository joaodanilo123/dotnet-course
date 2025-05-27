namespace WebApp.Repository;
class EmployeeRepository : IRepository<Employee>
{
    private static readonly List<Employee> employees = [
        new Employee(1, "Alice", "Developer", 60000),
        new Employee(2, "Bob", "Designer", 55000),
        new Employee(3, "Charlie", "Manager", 70000)
    ];

    public List<Employee> GetAll() => employees;

    public void Add(Employee? employee)
    {
        if (employee is not null)
        {
            employees.Add(employee);
        }
    }
}
