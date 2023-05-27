using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
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
    }
}
