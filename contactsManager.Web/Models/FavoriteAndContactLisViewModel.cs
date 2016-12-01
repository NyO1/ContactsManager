using System.Linq;

namespace contactsManager.Web.Models
{
    public class FavoriteAndContactLisViewModel
    {

        public IQueryable<Models.ContactListViewModel> ContactList { get; set; }

        public IQueryable<Models.FavoriteContactListViewModel> FavoriteContactList { get; set; }
       

        public FavoriteAndContactLisViewModel(IQueryable<Models.ContactListViewModel> model, IQueryable<Models.FavoriteContactListViewModel> modelFavorite)
        {
            ContactList = model;
            FavoriteContactList = modelFavorite;
        }

    }
}