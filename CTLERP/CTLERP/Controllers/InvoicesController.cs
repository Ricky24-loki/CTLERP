using CTLERP.Data;
using CTLERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CTLERP.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly ApplicationDbContext db;

        public InvoicesController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        public IActionResult Index()
        {
            var invoices = db.Invoices.Include(i => i.Order).ToList();
            return View(invoices);
        }

        public IActionResult New(int orderId)
        {
            var order = db.Orders.Include(o => o.OrderItems)
                                 .FirstOrDefault(o => o.Id == orderId);
            if (order == null)
            {
                return NotFound();
            }

            var invoice = new Invoice
            {
                OrderId = order.Id,
                AmountDue = order.AmountDue,
                DueDate = DateTime.Now.AddDays(30)
            };

            return View(invoice);
        }

        [HttpPost]
        public IActionResult New(Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                invoice.Date = DateTime.Now;
                invoice.AmountDue = db.Orders
                                      .Where(o => o.Id == invoice.OrderId)
                                      .Select(o => o.AmountDue)
                                      .FirstOrDefault();
                db.Invoices.Add(invoice);
                db.SaveChanges();
                return RedirectToAction("Index"); 
            }
            return View(invoice);
        }
    }
}
