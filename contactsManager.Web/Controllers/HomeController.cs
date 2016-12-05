using System.Linq;
using System.Runtime.InteropServices;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using contactsManager.Domain;
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

        //Search bar and 2 partial view (FavoriteContactListViewModel + ContactListViewModel = FavoriteAndContactListViewModel) 
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

            var modelFavorite = _db.Contacts
                .Where(c => c.Pref == true)
                .Take(6)
                .Select(c => new FavoriteContactListViewModel
                {
                    Id = c.Id,
                    PhotoUrl = c.PhotoUrl
                });

            var modelPage = new FavoriteAndContactLisViewModel(model, modelFavorite);

            //Partial per la ricerca
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Contacts", model);
            }

            return View(modelPage);
        }


        //GET Home/Edit/1
        public ActionResult Edit(int id)
        {   
           
            var contact = _db.Contacts.Single(c => c.Id == id);
            return View(contact);

        }


        //POST  Home/Edit/1
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contact contact)
        {
             if (ModelState.IsValid)
             {
                 var contactDb =_db.Contacts.FirstOrDefault(c => c.Id == contact.Id);
                 if (contactDb != null)
                 {
                     contactDb.FirstName = contact.FirstName;
                     contactDb.LastName = contact.LastName;
                     contactDb.Email = contact.Email;
                     contactDb.PhoneNumber = contact.PhoneNumber;
                     contactDb.Pref = contact.Pref;
                 } 
                
                 _db.Save();
             }

            return RedirectToAction("Index", "Home");
        }



        public ActionResult Detail(int id)
        {
            var contact = _db.Contacts.Single(c => c.Id == id);
            return View(contact);
        }

        //GET Home/Remove/1
        public ActionResult Remove(int id)
        {
            var contact = _db.Contacts.Single(c => c.Id == id);
            return View(contact);
        }

        //POST Home/Remove/id
        [System.Web.Mvc.HttpPost]
        public ActionResult Remove(Contact contact)
        {
            var contactDb = _db.Contacts.Single(c => c.Id == contact.Id);
            _db.Remove(contactDb);
            _db.Save();
            return RedirectToAction("Index", "Home");
        }

    }
}
