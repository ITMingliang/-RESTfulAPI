
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Three.Models;
using Three.Services;

namespace ThreeApi.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRespository _employeeRespository;

        public EmployeesController(IEmployeeRespository employeeRespository)
        {
            _employeeRespository = employeeRespository;
        }

        [HttpGet("{departmentId}")]//参数
        public async Task<IActionResult> GetByDepartmentId(int departmentId)
        {
            var employees = await _employeeRespository.GetByDepartmentId(departmentId);
            if (!employees.Any())
            {
                return NoContent();
            }
            return Ok(employees);
        }
        [HttpGet("One/{id}", Name = "GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _employeeRespository.GetById(id);
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Employee model)
        {
            //var added = await _employeeRespository.Add(model);

            //return CreatedAtRoute("GetById", new { id = added.Id }, added);

            var added = await _employeeRespository.Add(model);

            return CreatedAtRoute("GetById", new { id = added.Id }, added);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Fire(int id)
        {
            var result = await _employeeRespository.Fire(id);
            if (result != null)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
