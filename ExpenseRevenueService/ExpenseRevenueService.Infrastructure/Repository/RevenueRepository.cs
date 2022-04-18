using ExpenseRevenueService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseRevenueService.Infrastructure.Repository
{
    public class RevenueRepository : IRevenueRepository
    {
        private readonly EFContext _dbContext;

        public RevenueRepository(EFContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(RevenueEntity entites)
        {
            _dbContext.revenueEntities.Add(entites);
            Save();
        }

        public IEnumerable<RevenueEntity> GetExpense()
        {
            return _dbContext.revenueEntities.ToList();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(RevenueEntity entites)
        {
            _dbContext.Entry(entites).State = EntityState.Modified;
            Save();
        }
    }
}
