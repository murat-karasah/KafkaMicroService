using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuySellService.Domain.Entities
{
    public class SellEntity : BaseEntity
    {
        public int Piece { get; set; }
        public decimal Price { get; set; }
    }
}
