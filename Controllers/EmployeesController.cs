using Employee.Api.Models.Domain;
using Employee.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

[ApiController]
[Route("[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly EmpDatabaseService dbService = new();

    [HttpGet("employees")]
    public IActionResult GetAll()
    {
        var data = dbService.Load();
        return Ok(data.emp);
    }

    [HttpPost("employee")]
    public IActionResult Create(Employees employee)
    {
        var data = dbService.Load();

        data.emp.Add(employee);
        dbService.Save(data);
        return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
    }

    [HttpGet("empById")]
    public IActionResult GetById(int id)
    {
        var data = dbService.Load();
        var emp = data.emp.FirstOrDefault(e => e.Id.Equals(id));
        if (emp == null) return NotFound();
        return Ok(emp);
    }

    [HttpPut]
    public IActionResult Update(int id, Employees updated)
    {
        var data = dbService.Load();
        var emp = data.emp.FirstOrDefault(e => e.Id.Equals(id));
        if (emp == null) return NotFound();

        emp.Name = updated.Name;
        emp.Email = updated.Email;
        emp.PhoneNumber = updated.PhoneNumber;
        emp.Salary = updated.Salary;
        emp.Departments = updated.Departments;
        emp.RoleId = updated.RoleId;

        dbService.Save(data);
        return Ok(emp);
    }

    [HttpDelete("empDeleteId")]
    public IActionResult Delete(int id)
    {
        var data = dbService.Load();
        var emp = data.emp.FirstOrDefault(e => e.Id.Equals(id));
        if (emp == null)
            return NotFound();

        data.emp.Remove(emp);
        dbService.Save(data);
        return NoContent();
    }
}

