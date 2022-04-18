using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuySellService.Domain.Entities
{
    public class BuyEntity : BaseEntity
    {
        public decimal Amount { get; set; }
    }
}
