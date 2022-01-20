using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentACarProjectDemo.Models.Entity;

namespace RentACarProjectDemo.Controllers
{
    [Authorize]
    public class MotorcycleController : Controller
    {
        RentACarProjectEntities db = new RentACarProjectEntities();
        // GET: User
        public ActionResult Index()
        {
            var motorcycle = db.Motorcycles.ToList();
            return View(motorcycle);
        }
        [HttpGet]
        public ActionResult AddMotorcycle()
        {
            List<SelectListItem> deger1 = (from i in db.Brands.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.BrandName,
                                               Value = i.BrandId.ToString()

                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.Colors.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.ColorName,
                                               Value = i.ColorId.ToString()

                                           }).ToList();
            ViewBag.dgr2 = deger2;
            List<SelectListItem> deger3 = (from i in db.Models.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.ModelName,
                                               Value = i.ModelId.ToString()

                                           }).ToList();
            ViewBag.dgr3 = deger3;
            List<SelectListItem> deger4 = (from i in db.BodyTypes.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.BodyType,
                                               Value = i.BodyTypeId.ToString()

                                           }).ToList();
            ViewBag.dgr4 = deger4;
            List<SelectListItem> deger5 = (from i in db.Gears.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Gear,
                                               Value = i.GearId.ToString()

                                           }).ToList();
            ViewBag.dgr5 = deger5;
            List<SelectListItem> deger6 = (from i in db.FuelTypes.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.FuelType,
                                               Value = i.FuelTypeId.ToString()

                                           }).ToList();
            ViewBag.dgr6 = deger6;
            return View();
        }
        [HttpPost]
        public ActionResult AddMotorcycle(Motorcycles m)
        {
            var brn = db.Brands.Where(br => br.BrandId == m.Brands.BrandId).FirstOrDefault();
            var clr = db.Colors.Where(cl => cl.ColorId == m.Colors.ColorId).FirstOrDefault();
            var mdl = db.Models.Where(md => md.ModelId == m.Models.ModelId).FirstOrDefault();
            var bdy = db.BodyTypes.Where(bd => bd.BodyTypeId == m.BodyTypes.BodyTypeId).FirstOrDefault();
            var gr = db.Gears.Where(g => g.GearId == m.Gears.GearId).FirstOrDefault();
            var flt = db.FuelTypes.Where(f => f.FuelTypeId == m.FuelTypes.FuelTypeId).FirstOrDefault();
            m.Brands = brn;
            m.Colors = clr;
            m.Models = mdl;
            m.BodyTypes = bdy;
            m.Gears = gr;
            m.FuelTypes = flt;
            db.Motorcycles.Add(m);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteMotorcycle(int id)
        {
            db.Motorcycles.Remove(db.Motorcycles.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetMotorcycle(int id)
        {
            var mt = db.Motorcycles.Find(id);
            List<SelectListItem> deger1 = (from i in db.Brands.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.BrandName,
                                               Value = i.BrandId.ToString()

                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.Colors.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.ColorName,
                                               Value = i.ColorId.ToString()

                                           }).ToList();
            ViewBag.dgr2 = deger2;
            List<SelectListItem> deger3 = (from i in db.Models.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.ModelName,
                                               Value = i.ModelId.ToString()

                                           }).ToList();
            ViewBag.dgr3 = deger3;
            List<SelectListItem> deger4 = (from i in db.BodyTypes.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.BodyType,
                                               Value = i.BodyTypeId.ToString()

                                           }).ToList();
            ViewBag.dgr4 = deger4;
            List<SelectListItem> deger5 = (from i in db.Gears.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Gear,
                                               Value = i.GearId.ToString()

                                           }).ToList();
            ViewBag.dgr5 = deger5;
            List<SelectListItem> deger6 = (from i in db.FuelTypes.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.FuelType,
                                               Value = i.FuelTypeId.ToString()

                                           }).ToList();
            ViewBag.dgr6 = deger6;
            return View("GetMotorcycle", mt);
        }
        public ActionResult Updatemotorcycle (Motorcycles m)
        {
            var motorcycle = db.Motorcycles.Find(m.MotorcycleId);
            motorcycle.Decription = m.Decription;
            motorcycle.ModelYear = m.ModelYear;

            var brn = db.Brands.Where(br => br.BrandId == m.Brands.BrandId).FirstOrDefault();
            var clr = db.Colors.Where(cl => cl.ColorId == m.Colors.ColorId).FirstOrDefault();
            var mdl = db.Models.Where(md => md.ModelId == m.Models.ModelId).FirstOrDefault();
            var bdy = db.BodyTypes.Where(bd => bd.BodyTypeId == m.BodyTypes.BodyTypeId).FirstOrDefault();
            var gr = db.Gears.Where(g => g.GearId == m.Gears.GearId).FirstOrDefault();
            var flt = db.FuelTypes.Where(f => f.FuelTypeId == m.FuelTypes.FuelTypeId).FirstOrDefault();
            motorcycle.BrandId = brn.BrandId;
            motorcycle.ColorId = clr.ColorId;
            motorcycle.ModelId = mdl.ModelId;
            motorcycle.BodyTypeId = bdy.BodyTypeId;
            motorcycle.GearId = gr.GearId;
            motorcycle.FuelTypeId = flt.FuelTypeId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}