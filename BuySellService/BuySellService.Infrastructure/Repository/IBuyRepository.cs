using BuySellService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuySellService.Infrastructure.Repository
{
    public interface IBuyRepository
    {
        IEnumerable<BuyEntity> GetBuy();
        void Add(BuyEntity entites);
        BuyEntity GetById(int id);
        void Update(BuyEntity entites);
        void Delete(int id);
        void Save();
    }
}
