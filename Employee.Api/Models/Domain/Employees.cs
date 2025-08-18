namespace Employee.Api.Models.Domain;


    public class Employees
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public int  PhoneNumber { get; set; }
        public decimal Salary { get; set; }
        public string Departments { get; set; }
        public int RoleId { get; set; }
    }


