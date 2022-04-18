using ExpenseRevenueService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseRevenueService.Infrastructure.Repository
{
    public interface IExpenseRepository
    {
        IEnumerable<ExpenseEntity> GetExpense();

        void Add(ExpenseEntity entites);
        void Update(ExpenseEntity entites);
        void Save();

    }
}
