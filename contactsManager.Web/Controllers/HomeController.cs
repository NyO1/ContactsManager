using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using contactsManager.Domain;
using contactsManager.Web.Infrastructure;
using contactsManager.Web.Models;

namespace contactsManager.Web.Controllers
{
    public class HomeController : Controller
    {
        private IContactDataSource _db;

        public HomeController(IContactDataSource db)
        {
            _db = db;
        }


        public ActionResult Index(string searchTerm = null)
        {

            var model = _db.Contacts
                .OrderBy(c => c.FirstName)
                .Where(c => searchTerm == null || c.FirstName.StartsWith(searchTerm) || c.LastName.StartsWith(searchTerm))
                .Take(10)
                .Select(c => new ContactListViewModel
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    PhoneNumber = c.PhoneNumber,
                    PhotoUrl = c.PhotoUrl
                   
                });

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Contacts", model);
            }

            return View(model);
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
