using CTLERP.Data;
using CTLERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CTLERP.Controllers
{
    public class MeasureUnitsController : Controller
    {
        private readonly ApplicationDbContext db;

        public MeasureUnitsController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        public IActionResult Index()
        {
            var measureUnits = db.MeasureUnits.ToList();

            ViewBag.MeasureUnits = measureUnits;

            return View();
        }

        public IActionResult New()
        {
            MeasureUnit measureUnit = new MeasureUnit();
            return View(measureUnit);
        }

        [HttpPost]
        public IActionResult New(MeasureUnit newMeasureUnit)
        {
            if (ModelState.IsValid)
            {
                db.MeasureUnits.Add(newMeasureUnit);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(newMeasureUnit);
            }
        }

        public IActionResult Edit(int id)
        {
            var measureUnit = db.MeasureUnits.Find(id);

            if (measureUnit == null)
            {
                return NotFound();
            }

            return View(measureUnit);
        }

        [HttpPost]
        public IActionResult Edit(MeasureUnit updatedMeasureUnit)
        {
            if (ModelState.IsValid)
            {
                db.MeasureUnits.Update(updatedMeasureUnit);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(updatedMeasureUnit);
            }
        }

        public IActionResult Delete(int id)
        {
            var measureUnit = db.MeasureUnits.Find(id);

            if (measureUnit == null)
            {
                return NotFound();
            }

            return View(measureUnit);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var measureUnit = db.MeasureUnits.Find(id);

            if (measureUnit == null)
            {
                return NotFound();
            }

            db.MeasureUnits.Remove(measureUnit);
            db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
