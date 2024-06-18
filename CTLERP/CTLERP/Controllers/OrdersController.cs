using CTLERP.Data;
using CTLERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CTLERP.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext db;

        public OrdersController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        public IActionResult Index()
        {
            var orders = db.Orders.Include(o => o.OrderItems).ThenInclude(oi => oi.Product);
            ViewBag.Orders = orders;
            return View();
        }

        public IActionResult Details(int id)
        {
            var order = db.Orders.Include(o => o.Partner).Include(o => o.OrderItems)
                                 .ThenInclude(oi => oi.Product)
                                 .FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            ViewBag.Products = new SelectList(db.Products, "Id", "Name");
            ViewBag.Partners = new SelectList(db.Partners, "Id", "Name");
            return View(order);
        }

        [HttpPost]
        public IActionResult AddOrderItem(int orderId, OrderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                var product = db.Products.Find(orderItem.ProductId);
                if (product.Quantity < orderItem.Quantity)
                {
                    ModelState.AddModelError("", "Stoc insuficient!");
                }
                else
                {
                    orderItem.OrderId = orderId;
                    orderItem.Price = orderItem.Quantity * (decimal)product.Price;
                    db.OrdersItems.Add(orderItem);
                    product.Quantity -= orderItem.Quantity;
                    var currentOrder = db.Orders.Find(orderId);
                    currentOrder.AmountDue += (decimal)orderItem.Price;
                    db.SaveChanges();
                    return RedirectToAction(nameof(Details), new { id = orderId });
                }
            }

            var order = db.Orders.Include(o => o.OrderItems)
                                 .ThenInclude(oi => oi.Product)
                                 .FirstOrDefault(o => o.Id == orderId);
            ViewBag.Products = new SelectList(db.Products, "Id", "Name");
            ViewBag.Partners = new SelectList(db.Partners, "Id", "Name");
            return View("Details", order);
        }

        public IActionResult New()
        {
            ViewBag.Partners = new SelectList(db.Partners, "Id", "Name");
            var order = new Order
            {
                Date = DateTime.Now,
                IsValid = true
            };
            return View(order);
        }

        [HttpPost]
        public IActionResult New(Order newOrder)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(newOrder);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Partners = new SelectList(db.Partners, "Id", "Name");
            return View(newOrder);
        }

        public IActionResult Edit(int id)
        {
            var order = db.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewBag.Partners = new SelectList(db.Partners, "Id", "Name");
            return View(order);
        }

        [HttpPost]
        public IActionResult Edit(Order updatedOrder)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Update(updatedOrder);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Partners = new SelectList(db.Partners, "Id", "Name");
            return View(updatedOrder);
        }

        public IActionResult Delete(int id)
        {
            var order = db.Orders.Include(o => o.OrderItems).FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var order = db.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeleteOrderItem(int orderId, int orderItemId)
        {
            var orderItem = db.OrdersItems.Find(orderItemId);
            if (orderItem == null)
            {
                return NotFound();
            }

            var product = db.Products.Find(orderItem.ProductId);
            if (product != null)
            {
                product.Quantity += orderItem.Quantity;
            }

            var currentOrder = db.Orders.Find(orderId);
            currentOrder.AmountDue -= (decimal)orderItem.Price;

            db.OrdersItems.Remove(orderItem);
            db.SaveChanges();

            return RedirectToAction(nameof(Details), new { id = orderId });
        }



    }
}
