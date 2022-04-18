using ExpenseRevenueService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseRevenueService.Infrastructure.Repository
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly EFContext _dbContext;

        public ExpenseRepository(EFContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(ExpenseEntity entites)
        {
            _dbContext.expenseEntities.Add(entites);
            Save();
        }

        public IEnumerable<ExpenseEntity> GetExpense()
        {
            return _dbContext.expenseEntities.ToList();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(ExpenseEntity entites)
        {
            _dbContext.Entry(entites).State = EntityState.Modified;
            Save();
        }
    }
}
