using System.Diagnostics;
using HomeWork.Data;
using HomeWork.Entities;
using HomeWork.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductDbContext _context;

        public HomeController(ProductDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                ImagePath = p.ImagePath,
                Discount = p.Discount

            }).ToList();

            var vm = new ProductListViewModel
            {
                Products = products,
            };

            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Delete(int id) 
        {
            var item = _context.Products.FirstOrDefault(e => e.Id == id);
            _context.Products.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            var vm = new ProductViewModel();
            return View(vm);
        }

        [HttpPost]
        public IActionResult AddElement(ProductViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.Id = (new Random()).Next(1, 10000);
                _context.Products.Add(new Product { Id = vm.Id, Description = vm.Description, Discount = vm.Discount, ImagePath = vm.ImagePath, Name = vm.Name, Price = vm.Price });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
