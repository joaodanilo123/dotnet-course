namespace WebApp.Entity;

public class Employee(int id, string name, string position, double salary)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string Position { get; set; } = position;
    public double Salary { get; set; } = salary;
}
