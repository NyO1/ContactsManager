﻿using System.IO;
using System.Web;
using System.Web.Mvc;
using contactsManager.Domain;
using contactsManager.Web.Models;

namespace contactsManager.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactDataSource _db;

        public ContactController(IContactDataSource db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new CreateContactViewModel();

            return View(model);
        }

        
        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(CreateContactViewModel viewModel, HttpPostedFileBase file)
        {
           
            if (ModelState.IsValid && file!=null)
            {
                var contact = new Contact()
                {
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    PhoneNumber = viewModel.PhoneNumber,
                    Email = viewModel.Email,

                };

      
            string name = Path.GetFileName(file.FileName);
            string myfile = contact.Id + "_" + name;

            var path = Path.Combine(("~/Images/"), myfile);
            contact.PhotoUrl = path;
            file.SaveAs(Server.MapPath(path));
 
           _db.Add(contact);
           _db.Save();
           return RedirectToAction("Index", "Home");                

            }
            return View(viewModel);
        }






    }
}