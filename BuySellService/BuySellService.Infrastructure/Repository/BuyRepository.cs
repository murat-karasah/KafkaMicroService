using BuySellService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuySellService.Infrastructure.Repository
{
    public class BuyRepository : IBuyRepository
    {
        private readonly EFContext _dbContext;

        public BuyRepository(EFContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(BuyEntity entites)
        {
            _dbContext.Add(entites);
            Save();
        }

        public void Delete(int id)
        {
            var buy = _dbContext.buyEntities.FirstOrDefault(s => s.Id == id);
            _dbContext.buyEntities.Remove(buy);
            Save();
        }

        public IEnumerable<BuyEntity> GetBuy()
        {
            return _dbContext.buyEntities.ToList();
        }

        public BuyEntity GetById(int id)
        {
            return _dbContext.buyEntities.FirstOrDefault(s => s.Id == id);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(BuyEntity entites)
        {
            _dbContext.Entry(entites).State = EntityState.Modified;
            Save();
        }
    }
}
