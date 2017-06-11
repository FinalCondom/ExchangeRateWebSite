using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateDTO
{
    public class Currency
    {
        public int Id { get; set; }
        [Required]
        [StringLength(3)]
        [MinLength(3)]
        public String Name { get; set; }
        [Required]
        public String Statut { get; set; }
        [Required]
        public double Value { get; set; }
    }
}
