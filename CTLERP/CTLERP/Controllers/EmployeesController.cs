using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CTLERP.Data;
using CTLERP.Models;

namespace CTLERP.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext db;

        public EmployeesController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        // GET: Employees
        public IActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Manager).ToList();
            return View(employees);
        }

        // GET: Employees/Details/5
        public IActionResult Details(int id)
        {
            var employee = db.Employees.Include(e => e.Manager)
                                       .FirstOrDefault(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/New
        public IActionResult New()
        {
            ViewBag.Managers = new SelectList(db.Employees, "EmployeeId", "FirstName");
            return View();
        }

        // POST: Employees/New
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New([Bind("FirstName,LastName,DepartmentId,Position,HireDate,Salary,Email,PhoneNumber,ManagerId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Managers = new SelectList(db.Employees, "EmployeeId", "FirstName", employee.ManagerId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public IActionResult Edit(int id)
        {
            var employee = db.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewBag.Managers = new SelectList(db.Employees, "EmployeeId", "FirstName", employee.ManagerId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("EmployeeId,FirstName,LastName,DepartmentId,Position,HireDate,Salary,Email,PhoneNumber,ManagerId")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Employees.Update(employee);
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Managers = new SelectList(db.Employees, "EmployeeId", "FirstName", employee.ManagerId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public IActionResult Delete(int id)
        {
            var employee = db.Employees.Include(e => e.Manager)
                                       .FirstOrDefault(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return db.Employees.Any(e => e.EmployeeId == id);
        }
    }
}
