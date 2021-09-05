using Abstractions.Dtos;
using Abstractions.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace DirectoryApi.Controllers.V1
{
    [ApiController]
    [Produces("application/json")]
    [Route("v{version:apiVersion}/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("RaportCreate")]
        [ProducesResponseType(typeof(ReportsDto), statusCode: 200)]
        [AllowAnonymous]
        public async Task<IActionResult> RaportCreate()
        {
            var result = await _reportService.ReportCreate();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("ReportCapture")]
        [ProducesResponseType(typeof(ReportsDto), statusCode: 200)]
        [AllowAnonymous]
        public async Task<IActionResult> ReportCapture(ReportsDto reports)
        {
            var result = await _reportService.ReportCapture(reports);

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

    }
}
