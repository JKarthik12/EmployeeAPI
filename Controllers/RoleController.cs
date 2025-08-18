using Employee.Api.Models.Domain;
using Employee.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly RoleDatabaseService dbService = new();
    [HttpGet("roles")]
    public IActionResult GetAll()
    {
        var data = dbService.RoleLoad();
        return Ok(data.EmpRole);
    }

    [HttpPost]
    public IActionResult Create(Role role)
    {
        var data = dbService.RoleLoad();
        data.EmpRole.Add(role);
        dbService.Save(data);
        return CreatedAtAction(nameof(GetById), new { id = role.Id }, role);
    }

    [HttpGet]
    public IActionResult GetById(int id)
    {
        var data = dbService.RoleLoad();
        var RoleEmp = data.EmpRole.FirstOrDefault(r => r.Id.Equals(id));
        if (RoleEmp == null) return NotFound();
        return Ok(RoleEmp);
    }
    [HttpPut]
    public IActionResult Update(Role Updated)
    {
        var data = dbService.RoleLoad();
        var RoleEmp = data.EmpRole.FirstOrDefault(e => e.Id.Equals(Updated.Id));
        if (RoleEmp == null) return NotFound();
        RoleEmp.RoleName = Updated.RoleName;
        dbService.Save(data);
        return Ok(Update);
    }
}
