using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadingsController : ControllerBase
    {
        private IReadingService _readingService;
        public ReadingsController(IReadingService readingService)
        {
            _readingService = readingService;
        }

        [HttpGet("getReadingsBySerialNo")]
        public IActionResult getReadingsBySerialNo(int serialNo)
        {
            var result = _readingService.GetBySerialNo(serialNo);
            if(result.Success)
                return Ok(result);
            else
                return BadRequest();
        }

        [HttpGet("getAllReadings")]
        public IActionResult getAllReadings()
        {
            var result = _readingService.GetAll();
            if (result.Success)
                return Ok(result);
            else
                return BadRequest();
        }
        [HttpGet("getAllReadingsbyDateNow")]
        public IActionResult getAllReadingsbyDateNow()
        {
            var result = _readingService.GetByDates(DateTime.Today,DateTime.Today.AddDays(1));
            if (result.Success)
                return Ok(result);
            else
                return BadRequest();
        }
    }
    
}

