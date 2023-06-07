using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IReadingDal
    {
        public List<Reading> GetAll(Expression<Func<Reading,bool>> filter=null);
        public Reading Get(Expression<Func<Reading, bool>> filter);

        public List<ConsumptionDto> GetConsumptions(Expression<Func<Reading, bool>> filter=null);
    }
}
