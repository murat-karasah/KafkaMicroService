using BuySellService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuySellService.Infrastructure
{
    public class EFContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=TelosCaseDb;User ID=sa;Password=1q2w3e4r!^+;Trusted_Connection = false;");
        }
        public DbSet<BuyEntity> buyEntities { get; set; }
        public DbSet<SellEntity> SellEntity { get; set; }
    
    }
}
