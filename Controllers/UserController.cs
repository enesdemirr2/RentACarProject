using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentACarProjectDemo.Models.Entity;

namespace RentACarProjectDemo.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        RentACarProjectEntities db = new RentACarProjectEntities();   
        // GET: User
        public ActionResult Index()
        {
            var users = db.Users.ToList();
            return View(users);
        }
        [HttpGet]
        public ActionResult AddUser ()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(Users u)
        {
            db.Users.Add(u);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteUser (int id)
        {
             db.Users.Remove(db.Users.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateUser(int id)
        {
            Users u = db.Users.Find(id);
            return View(u);
        }
        [HttpPost]
        public ActionResult UpdateUser(Users u)
        {
            Users users = db.Users.Find(u.UserId);
            users.UserName = u.UserName;
            users.FirstName = u.FirstName;
            users.LastName = u.LastName;
            users.Password = u.Password;
            users.Email = u.Email;
            users.Telephone = u.Telephone;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}