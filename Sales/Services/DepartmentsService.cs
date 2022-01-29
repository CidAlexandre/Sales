using System;
using System.Collections.Generic;
using System.Linq;
using Sales.Data;
using Sales.Models;

namespace Sales.Services
{
    public class DepartmentsService
    {
        private readonly SalesContext _context;

        public DepartmentsService(SalesContext context)
        {
            _context = context;
        }

        public List<Departments> FindAll()
        {
            List<Departments> list = _context.Departments.OrderBy(x => x.Id).ToList();
            foreach(Departments i in list)
            {
                Console.WriteLine(i.Name);
            }
            return list;
        }
    }
}
