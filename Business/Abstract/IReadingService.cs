using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IReadingService
    {
        IDataResult<List<Reading>> GetBySerialNo(int serialNo);

        IDataResult<List<Reading>> GetByDates(DateTime min,DateTime max);
        IDataResult<List<Reading>> GetAll();
    }
}
