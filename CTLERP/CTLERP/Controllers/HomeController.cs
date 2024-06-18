using CTLERP.Data;
using CTLERP.Data.Migrations;
using CTLERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CTLERP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            db = dbContext;
        }

        public IActionResult Index()
        {
            ViewBag.LastOrders = GetLastKOrders(10);
            ViewBag.MostActivePartners = GetTopKActivePartners(5);
            ViewBag.ProductsLowInStock = GetProductsLowInStock();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public List<Models.Order> GetLastKOrders(int k)
        {
            return db.Orders
                .Include(o => o.OrderItems)
                .OrderByDescending(o => o.Date)
                .Take(k)
                .ToList();
        }

        public List<Models.Partner> GetTopKActivePartners(int k)
        {
            return db.Partners
                .Include(p => p.Orders)
                .OrderByDescending(p => p.Orders.Count)
                .Take(k)
                .ToList();
        }

        public List<Product> GetProductsLowInStock()
        {
            return db.Products
                .Include(p => p.MeasureUnit)
                .Where(p => p.Quantity < 5)
                .ToList();
        }
    }
}
