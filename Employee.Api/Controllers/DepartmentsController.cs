using Employee.Api.Models.Domain;
using Employee.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly DeptDatabaseService dbService = new();
        [HttpGet("depts")]
        public IActionResult GetAll()
        {
            var data = dbService.DeptLoad();
            return Ok(data.DeptEmp);
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            var data = dbService.DeptLoad();
            data.DeptEmp.Add(department);
            dbService.Save(data);
            return CreatedAtAction(nameof(GetById), new { id = department.Id }, department);
        }

        [HttpGet("get-by-id")]
        public IActionResult GetById(int id)
        {
            var data = dbService.DeptLoad();
            var DeptEmp = data.DeptEmp.FirstOrDefault(d => d.Id.Equals(id));
            if (DeptEmp == null) return NotFound();
            return Ok(DeptEmp);
        }
        [HttpPut]
        public IActionResult Update(Department Updated)
        {
            
            var data = dbService.DeptLoad();
            var DeptEmp = data.DeptEmp.FirstOrDefault(e => e.Id.Equals(Updated.Id));
            if (DeptEmp == null) return NotFound();
            DeptEmp.DepartmentsName = Updated.DepartmentsName;
            dbService.Save(data);
            return Ok(Update);

        }
    }
}
