using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sales.Services;
using Sales.Models;
using Sales.Models.ModelsViews;
using Sales.Services.Exceptions;

namespace Sales.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellersService _sellersService;
        private readonly DepartmentsService _departmentsService;
        public SellersController(SellersService sellersService, DepartmentsService departmentsService)
        {
            _sellersService = sellersService;
            _departmentsService = departmentsService;
        }
        public IActionResult Index()
        {
            var list = _sellersService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var departments = _departmentsService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellersService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = _sellersService.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellersService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if(id != null)
            {
                var obj = _sellersService.FindById(id.Value);
                if(obj != null)
                {
                    return View(obj);
                }
            }
            return NotFound();
        }

        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var obj = _sellersService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            List<Departments> departments = _departmentsService.FindAll();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id , Seller seller)
        {
            if(id != seller.Id)
            {
                return BadRequest();
            }
            try
            {
                _sellersService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch(NotFoundException)
            {
                return NotFound();
            }
            catch(DBConcurrencyException)
            {
                return BadRequest();
            }
        }
    }
}
