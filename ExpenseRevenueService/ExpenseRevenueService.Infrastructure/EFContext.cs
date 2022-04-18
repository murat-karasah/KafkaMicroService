using ExpenseRevenueService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseRevenueService.Infrastructure
{
    public class EFContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=TelosCaseDb;User ID=sa;Password=1q2w3e4r!^+;Trusted_Connection = false;");
        }
        public DbSet<ExpenseEntity> expenseEntities { get; set; }
        public DbSet<RevenueEntity> revenueEntities { get; set; }
    }
}