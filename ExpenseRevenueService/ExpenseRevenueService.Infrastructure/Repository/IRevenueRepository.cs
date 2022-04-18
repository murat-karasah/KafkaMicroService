using ExpenseRevenueService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseRevenueService.Infrastructure.Repository
{
    public interface IRevenueRepository
    {
        IEnumerable<RevenueEntity> GetExpense();

        void Add(RevenueEntity entites);
        void Update(RevenueEntity entites);
        void Save();


    }
}
