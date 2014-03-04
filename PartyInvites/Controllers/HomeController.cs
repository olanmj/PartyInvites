using PartyInvites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {  
        private ResponseDBContext db = new ResponseDBContext();
        //
        // GET: /Home/
        public ActionResult Index()
        {
            HttpCookie c = Request.Cookies.Get("phone");
            if (c == null)
            {
                c = new HttpCookie("phone", "12345");
            }
                c.Expires = DateTime.Now.AddDays(2);
                Response.Cookies.Add(c);

            DateTime time = DateTime.Now;
            string currentTime = time.ToShortTimeString();
            int hour = time.Hour;
            ViewBag.Time = currentTime;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View();
        }

        public ActionResult RsvpForm()
        {
            return View();
        }

        [HttpPost] 
        public ViewResult RsvpForm(GuestResponse guestResponse) {
            if (ModelState.IsValid)
            {
                db.Responses.Add(guestResponse);
                db.SaveChanges();
                return View("Thanks", guestResponse);
            }
            else
            {
                return View();
            }
        }

        public ViewResult List(bool? coming)
        {
            var rsvps = from r in db.Responses select r;

            if (coming != null)
            {
                rsvps = rsvps.Where(r => r.WillAttend == coming);
            }
            return View(rsvps);
        }

	}
}