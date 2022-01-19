using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sales.Models;

namespace Sales.Data
{
    public class SalesContext : DbContext
    {
        public SalesContext (DbContextOptions<SalesContext> options)
            : base(options)
        {
        }

        public DbSet<Sales.Models.Departments> Departments { get; set; }
        public DbSet<Sales.Models.Seller> Sellers { get; set; }
        public DbSet<Sales.Models.SalesRecord> SalesRecord { get; set; }


    }
}
