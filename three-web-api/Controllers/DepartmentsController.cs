
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Three.Models;
using ThreeApi.Repositories;

namespace ThreeApi.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRespository _departmentRespository;

        public DepartmentsController(IDepartmentRespository departmentRespository)
        {
            _departmentRespository = departmentRespository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        //public async Task<ActionResult<IEnumerable<Department>>> GetAll()
        {
            var departments = await _departmentRespository.GetAll();
            if (!departments.Any())
            {
                return NoContent();
            }
            return Ok(departments);
            //return new ObjectResult(departments);
        }
        [HttpPost]
        public async Task<ActionResult<Department>> Add([FromBody] Department department)
        {
            var added = await _departmentRespository.Add(department);

            return Ok(added);
        }
    }
}
