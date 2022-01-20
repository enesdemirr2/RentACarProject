using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentACarProjectDemo.Models.Entity;

namespace RentACarProjectDemo.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        RentACarProjectEntities db = new RentACarProjectEntities();
        // GET: Car
        public ActionResult Index()
        {
            var cars = db.Cars.ToList();

            return View(cars);
        }
        [HttpGet]
        public ActionResult AddCar()
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
        public ActionResult AddCar(Cars c)
        {
            var brn = db.Brands.Where(br => br.BrandId == c.Brands.BrandId).FirstOrDefault();
            var clr = db.Colors.Where(cl => cl.ColorId == c.Colors.ColorId).FirstOrDefault();
            var mdl = db.Models.Where(m => m.ModelId == c.Models.ModelId).FirstOrDefault();
            var bdy = db.BodyTypes.Where(bd => bd.BodyTypeId == c.BodyTypes.BodyTypeId).FirstOrDefault();
            var gr = db.Gears.Where(g => g.GearId == c.Gears.GearId).FirstOrDefault();
            var flt = db.FuelTypes.Where(f => f.FuelTypeId == c.FuelTypes.FuelTypeId).FirstOrDefault();
            c.Brands = brn;
            c.Colors = clr;
            c.Models = mdl;
            c.BodyTypes = bdy;
            c.Gears = gr;
            c.FuelTypes = flt;
            db.Cars.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCar(int id)
        {
            var car = db.Cars.Find(id);
            db.Cars.Remove(car);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCar(int id)
        {
            var cr = db.Cars.Find(id);
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
            return View("GetCar", cr);
        }
        public ActionResult UpdateCar(Cars c)
        {
            var _car = db.Cars.Find(c.CarId);
            _car.Decription = c.Decription;
            _car.ModelYear = c.ModelYear;

            var brn = db.Brands.Where(br => br.BrandId == c.Brands.BrandId).FirstOrDefault();
            var clr = db.Colors.Where(cl => cl.ColorId == c.Colors.ColorId).FirstOrDefault();
            var mdl = db.Models.Where(m => m.ModelId == c.Models.ModelId).FirstOrDefault();
            var bdy = db.BodyTypes.Where(bd => bd.BodyTypeId == c.BodyTypes.BodyTypeId).FirstOrDefault();
            var gr = db.Gears.Where(g => g.GearId == c.Gears.GearId).FirstOrDefault();
            var flt = db.FuelTypes.Where(f => f.FuelTypeId == c.FuelTypes.FuelTypeId).FirstOrDefault();
            _car.BrandId = brn.BrandId;
            _car.ColorId = clr.ColorId;
            _car.ModelId = mdl.ModelId;
            _car.BodyTypeId = bdy.BodyTypeId;
            _car.GearId = gr.GearId;
            _car.FuelTypeId = flt.FuelTypeId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}