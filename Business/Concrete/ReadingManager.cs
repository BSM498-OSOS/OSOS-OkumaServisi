using Business.Abstract;
using Core.Extensions;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ReadingManager : IReadingService
    {
        private IReadingDal _readingDal;

        public ReadingManager(IReadingDal readingDal)
        {
            _readingDal = readingDal;
        }

        public IDataResult<List<Reading>> GetAll()
        {
            var result = _readingDal.GetAll();
            if(result.Count > 0)
            {
                return new SuccessDataResult<List<Reading>>(result);
            }
            return new ErrorDataResult<List<Reading>>();
        }

        public IDataResult<List<ConsumptionDto>> GetAllConsumptions()
        {
            /*var result = _readingDal.GetAll()
                .GroupBy(r => r.Obis000)
                .Select(x=>new ConsumptionDto 
                { Obis000=x.First().Obis000,
                Consumptions=x.GroupBy(a=>a.Obis092.Date)
                .SelectWithPreviousElement((prev,curr)=>new Consumption 
                { 
                    Date=curr.First().Obis092.Date,
                    TotalConsumption= prev == null ? curr.Last().Obis180 : curr.Last().Obis180 - prev.Last().Obis180
                }).ToList()
                }).ToList();*/
            var result = _readingDal.GetConsumptions();
            if( result.Count > 0 )
            {
                return new SuccessDataResult<List<ConsumptionDto>>(result);
            }
            return new ErrorDataResult<List<ConsumptionDto>>();
        }

        public IDataResult<List<Consumption>> GetAllConsumptionsDaily()
        {
            var result = _readingDal.GetConsumptions().SelectMany(r => r.Consumptions, (parent, child) => new { date = child.Date, consumption = child.TotalConsumption })
            .GroupBy(a => new { a.date.Year, a.date.Month,a.date.Day }).Select(a => new Consumption
            {
                Date = new DateTime(a.First().date.Year, a.First().date.Month, a.First().date.Day),
                TotalConsumption = a.Select(a => a.consumption).Sum()
            }).ToList();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<Consumption>>(result);
            }
            return new ErrorDataResult<List<Consumption>>();
        }

        public IDataResult<List<Consumption>> GetAllConsumptionsMontly()
        {
            var result = _readingDal.GetConsumptions().SelectMany(r => r.Consumptions, (parent, child) => new { date = child.Date, consumption = child.TotalConsumption })
            .GroupBy(a => new { a.date.Year, a.date.Month }).Select(a => new Consumption
            {
                Date = new DateTime(a.First().date.Year, a.First().date.Month, 1),
                TotalConsumption = a.Select(a => a.consumption).Sum()
            }).ToList();
            if(result.Count>0)
            {
                return new SuccessDataResult<List<Consumption>>(result);
            }
            return new ErrorDataResult<List<Consumption>>();
        }

        public IDataResult<List<Consumption>> GetAllConsumptionsYearly()
        {
            var result = _readingDal.GetConsumptions().SelectMany(r => r.Consumptions, (parent, child) => new { date = child.Date, consumption = child.TotalConsumption })
            .GroupBy(a => new { a.date.Year}).Select(a => new Consumption
            {
                Date = new DateTime(a.First().date.Year, 12, 31),
                TotalConsumption = a.Select(a => a.consumption).Sum()
            }).ToList();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<Consumption>>(result);
            }
            return new ErrorDataResult<List<Consumption>>();
        }

        public IDataResult<List<Reading>> GetByDates(DateTime min,DateTime max)
        {
            var result = _readingDal.GetAll(r => r.Obis092 >= min && r.Obis092<=max);
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<Reading>>(result);
            }
            return new ErrorDataResult<List<Reading>>();
        }

        public IDataResult<List<Reading>> GetBySerialNo(int serialNo)
        {
            var result = _readingDal.GetAll(r=>r.Obis000==serialNo);
            if (result.Count>0)
            {
                return new SuccessDataResult<List<Reading>>(result);
            }
            return new ErrorDataResult<List<Reading>>();
        }

        public IDataResult<ConsumptionDto> GetConsumptionsBySerialNo(int serialNo)
        {
            var result = _readingDal.GetConsumptions(r=>r.Obis000==serialNo).FirstOrDefault();
            if (result!=null)
            {
                return new SuccessDataResult<ConsumptionDto>(result);
            }
            return new ErrorDataResult<ConsumptionDto>();
        }

        public IDataResult<List<Consumption>> GetConsumptionsDailyBySerialNo(int serialNo)
        {
            var result = _readingDal.GetConsumptions(r => r.Obis000 == serialNo).FirstOrDefault()?.Consumptions
        .GroupBy(a => new { a.Date.Year, a.Date.Month ,a.Date.Day}).Select(a => new Consumption
        {
            Date = new DateTime(a.First().Date.Year, a.First().Date.Month, a.First().Date.Day),
            TotalConsumption = a.Select(a => a.TotalConsumption).Sum()
        }).ToList(); ;
            if (result != null)
            {
                return new SuccessDataResult<List<Consumption>>(result);
            }
            return new ErrorDataResult<List<Consumption>>();
        }

        public IDataResult<List<Consumption>> GetConsumptionsMontlyBySerialNo(int serialNo)
        {
            var result = _readingDal.GetConsumptions(r => r.Obis000 == serialNo).FirstOrDefault()?.Consumptions
        .GroupBy(a => new { a.Date.Year, a.Date.Month }).Select(a => new Consumption
        {
            Date = new DateTime(a.First().Date.Year, a.First().Date.Month, 1),
            TotalConsumption = a.Select(a => a.TotalConsumption).Sum()
        }).ToList(); ;
            if (result != null)
            {
                return new SuccessDataResult<List<Consumption>>(result);
            }
            return new ErrorDataResult<List<Consumption>>();
            /*SelectMany(r => r.Consumptions, (parent, child) => new { date = child.Date, consumption = child.TotalConsumption })
        .GroupBy(a => new { a.date.Year, a.date.Month }).Select(a => new Consumption
        {
            Date = new DateTime(a.First().date.Year, a.First().date.Month, 1),
            TotalConsumption = a.Select(a => a.consumption).Sum()
        }).ToList();*/
        }

        public IDataResult<List<Consumption>> GetConsumptionsYearlyBySerialNo(int serialNo)
        {
            var result = _readingDal.GetConsumptions(r => r.Obis000 == serialNo).FirstOrDefault()?.Consumptions
        .GroupBy(a => new { a.Date.Year }).Select(a => new Consumption
        {
            Date = new DateTime(a.First().Date.Year, 12, 31),
            TotalConsumption = a.Select(a => a.TotalConsumption).Sum()
        }).ToList(); ;
            if (result != null)
            {
                return new SuccessDataResult<List<Consumption>>(result);
            }
            return new ErrorDataResult<List<Consumption>>();
        }
    }
}
