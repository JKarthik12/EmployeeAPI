using Employee.Api.Models.Domain;

public class DataStore
{
    public List<Employees> emp { get; set; } = new();
    public List<Department> DeptEmp { get; set; } = new();
    public List<Role> EmpRole { get; set; } = new();
}

