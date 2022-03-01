using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeApi.Repositories;

namespace ThreeApi.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class SummaryController : ControllerBase
    {
        private readonly ISummaryRespository _summaryRespository;

        public SummaryController(ISummaryRespository summaryRespository)
        {
            this._summaryRespository = summaryRespository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _summaryRespository.GetCompanySummary();

            return Ok(result);
        }
    }
}
