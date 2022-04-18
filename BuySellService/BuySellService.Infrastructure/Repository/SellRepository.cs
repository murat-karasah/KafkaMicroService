using BuySellService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuySellService.Infrastructure.Repository
{
    public class SellRepository : ISellRepository
    {
        private readonly EFContext _dbContext;

        public SellRepository(EFContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(SellEntity entites)
        {
            _dbContext.SellEntity.Add(entites);
            Save();
        }

        public void Delete(int id)
        {
            var sel = _dbContext.SellEntity.FirstOrDefault(s => s.Id == id);
            _dbContext.SellEntity.Remove(sel);
            Save();
        }

        public IEnumerable<SellEntity> GetBuy()
        {
            return _dbContext.SellEntity.ToList();
        }

        public SellEntity GetById(int id)
        {
            return _dbContext.SellEntity.FirstOrDefault(s => s.Id == id);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(SellEntity entites)
        {
            _dbContext.Entry(entites).State = EntityState.Modified;
            Save();
        }
    }
}
