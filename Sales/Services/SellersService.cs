using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sales.Data;
using Sales.Models;

namespace Sales.Services
{
    public class SellersService
    {
        private readonly SalesContext _context;

        public SellersService(SalesContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Sellers.ToList();
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

    }
}
