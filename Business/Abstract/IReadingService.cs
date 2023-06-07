using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Concrete.DTOs;
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

        IDataResult<List<ConsumptionDto>> GetAllConsumptions();
        IDataResult<ConsumptionDto> GetConsumptionsBySerialNo(int serialNo);
        IDataResult<List<Consumption>> GetAllConsumptionsMontly();
        IDataResult<List<Consumption>> GetAllConsumptionsDaily();
        IDataResult<List<Consumption>> GetAllConsumptionsYearly();

        IDataResult<List<Consumption>> GetConsumptionsMontlyBySerialNo(int serialNo);
        IDataResult<List<Consumption>> GetConsumptionsDailyBySerialNo(int serialNo);
        IDataResult<List<Consumption>> GetConsumptionsYearlyBySerialNo(int serialNo);
    }
}
