namespace Employee.Api.Models.Domain;

public class Department
{
    public int Id { get; set; }
    public string DepartmentsName { get; set; }
}

public static class DepartmentMap
{
    public static readonly Dictionary<string, string> DeptMappings = new()
    {
        { "101", "IT" },
        { "102", "HR" },
        { "103", "Finance" },
        { "104", "Marketing" }
    };
}