using Business.Dtos;
using Business.Services;
using Data.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace innofocus.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HikerController : ControllerBase
    {
        
        private readonly ILogger<HikerController> _logger;
        private readonly IHikerService _hikerService;

        public HikerController(ILogger<HikerController> logger, IHikerService hikerService)
        {
            _logger = logger;
            _hikerService = hikerService;
        }

        [Route("AddHiker")]
        [HttpPost]
        public async Task<Hiker> AddHiker(AddHikerInput input)
        {
            try
            {
                var result = await _hikerService.AddHiker(input);
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw e;
            }
        }

        [Route("UpdateHikerLocation")]
        [HttpPost]
        public async Task<Hiker> UpdateHikerLocation(UpdateHikerLocationInput input)
        {
            try
            {
                var result = await _hikerService.UpdateHikerLocation(input);
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw e;
            }
        }

        [Route("MarkHikerInjured/{id}")]
        [HttpPost]
        public async Task<Hiker> MarkHikerInjured(int id)
        {
            try
            {
                var result = await _hikerService.MarkHikerInjured(id);
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw e;
            }
        }

        //trade items

        [Route("TradeItems")]
        [HttpPost]
        public async Task<Hiker> TradeItems(TradeItemsInput input)
        {
            try
            {
                var result = await _hikerService.TradeItems(input);
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw e;
            }
        }

    }
}