using CTLERP.Data;
using CTLERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CTLERP.Controllers
{
    public class PartnersController : Controller
    {
        private readonly ApplicationDbContext db;

        public PartnersController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        public IActionResult Index()
        {
            var partners = db.Partners.Include(p => p.PartnerType).ToList();
            ViewBag.Partners = partners;
            return View();
        }

        public IActionResult Details(int id)
        {
            var partner = db.Partners.Include("PartnerType").Where(p => p.Id == id).FirstOrDefault();
            if (partner == null)
            {
                return NotFound();
            }
            ViewBag.Partner = partner;
            return View(partner);
        }

        public IActionResult New()
        {
            Partner partner = new Partner();
            partner.Type = GetAllPartnerTypes();
            return View(partner);
        }

        [HttpPost]
        public IActionResult New(Partner newPartner)
        {
            if (ModelState.IsValid)
            {
                db.Partners.Add(newPartner);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                newPartner.Type = GetAllPartnerTypes();
                return View(newPartner);
            }
        }


        public IActionResult Edit(int id)
        {
            var partner = db.Partners.Include("PartnerType").FirstOrDefault(p => p.Id == id);
            if (partner == null)
            {
                return NotFound();
            }
            partner.Type = GetAllPartnerTypes();
            return View(partner);
        }

        [HttpPost]
        public IActionResult Edit(Partner updatedPartner)
        {
            if (ModelState.IsValid)
            {
                db.Partners.Update(updatedPartner);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                updatedPartner.Type = GetAllPartnerTypes();
                return View(updatedPartner);
            }
        }

        [NonAction]
        public IEnumerable<SelectListItem> GetAllPartnerTypes()
        {
            var selectList = new List<SelectListItem>();
            var types = from type in db.PartnerTypes select type;
            foreach (var type in types)
            {
                selectList.Add(new SelectListItem
                {
                    Value = type.Id.ToString(),
                    Text = type.Name.ToString()
                });
            }
            return selectList;
        }

        public IActionResult Delete(int id)
        {
            var partner = db.Partners.Include("PartnerType").Where(p => p.Id == id).FirstOrDefault();
            if (partner == null)
            {
                return NotFound();
            }
            return View(partner);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var partner = db.Partners.Find(id);
            if (partner == null)
            {
                return NotFound();
            }
            db.Partners.Remove(partner);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
