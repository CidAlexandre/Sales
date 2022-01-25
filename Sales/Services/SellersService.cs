using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sales.Data;
using Sales.Models;
using Microsoft.EntityFrameworkCore;

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
        public Seller FindById(int id)
        {
            return _context.Sellers.Include(x => x.Departments).FirstOrDefault(x => x.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Sellers.Find(id);
            _context.Sellers.Remove(obj);
            _context.SaveChanges();
        }

    }
}
