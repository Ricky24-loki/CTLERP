using CTLERP.Data;
using CTLERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CTLERP.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext db;

        public ProductsController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        public IActionResult Index()
        {
            var products = db.Products.Include("MeasureUnit");

            ViewBag.Products = products;

            return View();
        }

        public IActionResult Details(int id)
        {
            var product = db.Products.Include("MeasureUnit").Where(p => p.Id == id).First();

            ViewBag.Product = product;

            return View();
        }

        public IActionResult New()
        {
            Product p = new Product();
            p.Unit = GetAllUnits();
            return View(p);
        }

        [HttpPost]
        public IActionResult New(Product newProduct)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(newProduct);
                db.SaveChanges();
                newProduct = new Product();
                newProduct.Unit = GetAllUnits();
                return View(newProduct);
            }
            else
            {
                newProduct.Unit = GetAllUnits();
                return View(newProduct);
            }
        }

        public IActionResult Edit(int id)
        {
            var product = db.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            product.Unit = GetAllUnits();
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product updatedProduct)
        {
            if (ModelState.IsValid)
            {
                db.Products.Update(updatedProduct);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                updatedProduct.Unit = GetAllUnits();
                return View(updatedProduct);
            }
        }


        [NonAction]
        public IEnumerable<SelectListItem> GetAllUnits()
        {
            var selectList = new List<SelectListItem>();
            var units = from unit in db.MeasureUnits select unit;
            foreach (var unit in units)
            {
                selectList.Add(new SelectListItem
                {
                    Value = unit.Id.ToString(),
                    Text = unit.Name.ToString()
                });
            }
            return selectList;
        }

        public IActionResult Delete(int id)
        {
            var product = db.Products.Include("MeasureUnit").Where(p => p.Id == id).FirstOrDefault();

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = db.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
