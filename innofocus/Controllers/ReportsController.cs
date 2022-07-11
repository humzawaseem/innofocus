using Business.Dtos;
using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace innofocus.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly ILogger<HikerController> _logger;
        private readonly IReportService _reportService;

        public ReportsController(ILogger<HikerController> logger, IReportService reportService)
        {
            _logger = logger;
            _reportService = reportService;
        }

        
        [HttpGet]
        [Route("PercentageReportInjuredHikers")]
        public async Task<double> PercentageReportInjuredHikers()
        {
            try
            {
                var result = await _reportService.PercentageReportInjuredHikers();
                return result;
            }
            catch (Exception e)
            {
                return 0;
            }
        }


        [HttpGet]
        [Route("PercentageReportNonInjuredHikers")]
        public async Task<double> PercentageReportNonInjuredHikers()
        {
            try
            {
                var result = await _reportService.PercentageReportNonInjuredHikers();
                return result;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        [HttpGet]
        [Route("ItemsOwnedByHikers")]
        public async Task<List<ItemReportDto>> ItemsOwnedByHikers()
        {
            try
            {
                var result = await _reportService.ItemsOwnedByHikers();
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return new List<ItemReportDto>();
            }
        }

        [HttpGet]
        [Route("ItemPointsLostByInjuredHikers")]
        public async Task<double> ItemPointsLostByInjuredHikers()
        {
            try
            {
                var result = await _reportService.ItemPointsLostByInjuredHikers();
                return result;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

    }
}
