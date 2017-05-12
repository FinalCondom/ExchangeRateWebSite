using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateDTO
{
    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public string Statut { get; set; }
    }
}
