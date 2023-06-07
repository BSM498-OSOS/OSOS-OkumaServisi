using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Concrete.DTOs;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Extensions;

namespace DataAccess.Concrete
{
    public class ReadingDal : IReadingDal
    {

        public Reading Get(Expression<Func<Reading, bool>> filter)
        {
            using(var context = new ReadingsDbContext())
            {
                var result=context.Collection.Find(filter).FirstOrDefault();
                return result;
            }
        }

        public List<Reading> GetAll(Expression<Func<Reading, bool>> filter = null)
        {
            using (var context = new ReadingsDbContext())
            {
                if(filter != null)
                {
                    var result = context.Collection.Find(filter).ToList();
                    return result;
                }
                else
                {
                    var result = context.Collection.Find(_=>true).ToList();
                    return result;
                }
                   
            }
        }

        public List<ConsumptionDto> GetConsumptions(Expression<Func<Reading, bool>> filter = null)
        {
            using (var context = new ReadingsDbContext())
            {
                if (filter != null)
                {
                    var result = context.Collection.Find(filter).ToEnumerable().GroupBy(r => r.Obis000)
                    .Select(x => new ConsumptionDto
                    {
                        Obis000 = x.First().Obis000,
                        Consumptions = x.GroupBy(a => a.Obis092.Date)
                        .SelectWithPreviousElement((prev, curr) => new Consumption
                        {
                        Date = curr.First().Obis092.Date,
                        TotalConsumption = prev == null ? curr.Last().Obis180 : curr.Last().Obis180 - prev.Last().Obis180
                        }).ToList()
                    }).ToList();
                    return result;
                }
                else
                {
                    var result = context.Collection.Find(_ => true).ToEnumerable().GroupBy(r => r.Obis000)
                    .Select(x => new ConsumptionDto
                    {
                        Obis000 = x.First().Obis000,
                        Consumptions = x.GroupBy(a => a.Obis092.Date)
                        .SelectWithPreviousElement((prev, curr) => new Consumption
                        {
                            Date = curr.First().Obis092.Date,
                            TotalConsumption = prev == null ? curr.Last().Obis180 : curr.Last().Obis180 - prev.Last().Obis180
                        }).ToList()
                    }).ToList(); 
                    return result;
                }

            }
        }
    }
}
