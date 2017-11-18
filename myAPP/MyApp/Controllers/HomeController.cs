using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyApp.Controllers
{
    public class HomeController : Controller
    {
        private UkraineAirlineEntities db = new UkraineAirlineEntities();
        private UkraineAirlineEntities2 db1 = new UkraineAirlineEntities2();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Register(Registration reg)
        {
            if (ModelState.IsValid)
            {
                db.Registrations.Add(reg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(Registration reg)
        {
            if (ModelState.IsValid)
            {
                var details = (from userList in db.Registrations
                               where userList.Email == reg.Email && userList.Password == reg.Password
                               select new
                               {
                                   userList.Id,
                                   userList.Email,

                               }).ToList();
                if (details.FirstOrDefault() != null)
                {
                    Session["Id"] = details.FirstOrDefault().Id;
                    Session["Email"] = details.FirstOrDefault().Email;
                    return RedirectToAction("Welcome", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid Credentials");
            }
            return View(reg);
        }

        public ActionResult welcome()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult welcome(Booking book)
        {
            if (ModelState.IsValid)
            {
                db1.Bookings.Add(book);
                db1.SaveChanges();
                return RedirectToAction("Payment");
            }
            return View();
        }

        public ActionResult Payment()
        {

            return View(db1.Bookings.ToList());
        }

        public ActionResult Cancel(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking bookingDetails = db1.Bookings.Find(Id);
            if (bookingDetails == null)
            {
                return HttpNotFound();
            }
            return View(bookingDetails);
        }

        [HttpPost, ActionName("Cancel")]
        [ValidateAntiForgeryToken]

        public ActionResult CancelConfirmed(int Id) 
        {
            Booking bookingDetails = db1.Bookings.Find(Id);
            db1.Bookings.Remove(bookingDetails);
            db1.SaveChanges();
            return RedirectToAction("welcome");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Pay()
        {
            return View();
        }
    }
}