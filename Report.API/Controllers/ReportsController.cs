using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Report.API.Dtos;
using Report.API.Services;

namespace Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _reportService.GetAllReportsAsync();

            return new OkObjectResult(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReportByIdAsync(string id)
        {
            var response = await _reportService.GetReportByIdAsync(id);

            return new OkObjectResult(response);
        }

        [HttpPost]
        public async Task<IActionResult> ReportSuspend(ReportRequestDto reportRequestDto)
        {
            var response = await _reportService.ReportSuspend(reportRequestDto);

            if (response)
                return Ok();
            else
                return NotFound();
        }
    }
}
