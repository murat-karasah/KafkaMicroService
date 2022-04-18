using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseRevenueService.Domain.Entities
{
    public class ExpenseEntity : BaseEntity
    {
        public decimal Amount { get; set; }

    }
}
