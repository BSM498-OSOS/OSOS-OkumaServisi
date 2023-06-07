using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete.DTOs
{
    public class ConsumptionDto:IDto
    {
        public int Obis000 { get; set; }
        public List<Consumption> Consumptions { get; set; }
    }
    public class Consumption
    {
        public DateTime Date { get; set; }
        public decimal TotalConsumption { get; set; }
    }
}
