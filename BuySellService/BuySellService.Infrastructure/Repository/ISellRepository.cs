using BuySellService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuySellService.Infrastructure.Repository
{
    public interface ISellRepository
    {
        IEnumerable<SellEntity> GetBuy();
        void Add(SellEntity entites);
        SellEntity GetById(int id);
        void Update(SellEntity entites);
        void Delete(int id);
        void Save();
    }
}
