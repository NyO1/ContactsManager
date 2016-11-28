using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using contactsManager.Domain;
using contactsManager.Web.Infrastructure;

namespace contactsManager.Web.Controllers
{
    public class HomeController : Controller
    {
        private IContactDataSource _db;

        public HomeController(IContactDataSource db)
        {
            _db = db;
        }


        public ActionResult Index()
        {
            var allContacts =  _db.Contacts;

            return View(allContacts);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Detail(int id)
        {
            var contact = _db.Contacts.Single(c => c.Id == id);
            return View(contact);
        }

    }
}
