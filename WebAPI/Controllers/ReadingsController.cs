using Business.Abstract;
using Core.Extensions;
using Entity.Concrete;
using Entity.Concrete.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Linq;
using System.Runtime.CompilerServices;

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
                return Ok(result.Data);
            else
                return BadRequest();
        }

        [HttpGet("getAllReadings")]
        public IActionResult getAllReadings()
        {
            var result = _readingService.GetAll();
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest();
        }
        [HttpGet("getAllReadingsbyDateNow")]
        public IActionResult getAllReadingsbyDateNow()
        {
            var result = _readingService.GetByDates(DateTime.Today,DateTime.Today.AddDays(1));
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest();
        }


        [HttpGet("getAllReadingsbyDates")]
        public IActionResult getAllReadingsbyDates(DateTime minDate,DateTime maxDate)
        {
            var result = _readingService.GetByDates(minDate.ToUniversalTime(), maxDate.ToUniversalTime());
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest();
        }


        [HttpGet("getAllTotalConsumptions")]
        public IActionResult getAllTotalConsumptions()
        {
            var result = _readingService.GetAllConsumptions();//_readingService.GetAll();
           /* var itemsGroupBySerialNo = result.Data.GroupBy(x => x.Obis000).Select(x => new
            {
                obis000=x.First().Obis000,
                consumptions=x.GroupBy(x=>x.Obis092.Date).SelectWithPreviousElement((prev,curr)=>new { 
                    date=x.First().Obis092.Date,
                    consumption=prev==null?curr.Last().Obis180:curr.Last().Obis180-prev.Last().Obis180
                })
            }).ToList();*/
           if(result.Success)
            return Ok(result.Data);
           return BadRequest();
        }

        [HttpGet("getAllTotalConsumptionsBySerialNo")]
        public IActionResult getAllTotalConsumptionsBySerialNo(int serialNo)
        {
            var result = _readingService.GetConsumptionsBySerialNo(serialNo);/*_readingService.GetAllConsumptions().Data.SelectMany(r=>r.Consumptions,(parent,child)=>new {date=child.Date, consumption =child.TotalConsumption})
            .GroupBy(a => new {a.date.Year,a.date.Month}).Select(a => new
            {
                date = new DateTime(a.First().date.Year, a.First().date.Month,1),
                totalConsumtion= a.Select(a => a.consumption).Sum()
            });*/
            if (result.Success)
                return Ok(result.Data);
            return BadRequest();
        }


        [HttpGet("getAllTotalConsumptionDaily")]
        public IActionResult getAllTotalConsumptionDaily()
        {
            var result = _readingService.GetAllConsumptionsDaily();
            if (result.Success)
                return Ok(result.Data);
            return BadRequest();
        }


        [HttpGet("getAllTotalConsumptionMonthly")]
        public IActionResult getAllTotalConsumptionMonthly()
        {
            var result = _readingService.GetAllConsumptionsMontly();/*_readingService.GetAllConsumptions().Data.SelectMany(r=>r.Consumptions,(parent,child)=>new {date=child.Date, consumption =child.TotalConsumption})
            .GroupBy(a => new {a.date.Year,a.date.Month}).Select(a => new
            {
                date = new DateTime(a.First().date.Year, a.First().date.Month,1),
                totalConsumtion= a.Select(a => a.consumption).Sum()
            });*/
            if(result.Success)
             return Ok(result.Data);
            return BadRequest();
        }


        [HttpGet("getAllTotalConsumptionYearly")]
        public IActionResult getAllTotalConsumptionYearly()
        {
            var result = _readingService.GetAllConsumptionsYearly();
            if (result.Success)
                return Ok(result.Data);
            return BadRequest();
        }


        [HttpGet("getTotalConsumptionDailyBySerialNo")]
        public IActionResult getTotalConsumptionDailyBySerialNo(int serialNo)
        {
            var result = _readingService.GetConsumptionsDailyBySerialNo(serialNo);
            if (result.Success)
                return Ok(result.Data);
            return BadRequest();
        }

        [HttpGet("getTotalConsumptionMonthlyBySerialNo")]
        public IActionResult getTotalConsumptionMonthlyBySerialNo(int serialNo)
        {
            var result = _readingService.GetConsumptionsMontlyBySerialNo(serialNo);/*_readingService.GetAllConsumptions().Data.SelectMany(r=>r.Consumptions,(parent,child)=>new {date=child.Date, consumption =child.TotalConsumption})
            .GroupBy(a => new {a.date.Year,a.date.Month}).Select(a => new
            {
                date = new DateTime(a.First().date.Year, a.First().date.Month,1),
                totalConsumtion= a.Select(a => a.consumption).Sum()
            });*/
            if (result.Success)
                return Ok(result.Data);
            return BadRequest();
        }

        [HttpGet("getTotalConsumptionYearlyBySerialNo")]
        public IActionResult getTotalConsumptionYearlyBySerialNo(int serialNo)
        {
            var result = _readingService.GetConsumptionsYearlyBySerialNo(serialNo);
            if (result.Success)
                return Ok(result.Data);
            return BadRequest();
        }

    }
   
}


