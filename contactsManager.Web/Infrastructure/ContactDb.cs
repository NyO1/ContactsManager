using System;
using System.Data.Entity;
using System.Linq;
using contactsManager.Domain;



namespace contactsManager.Web.Infrastructure
{
    public class ContactDb : DbContext, IContactDataSource
    {
        public ContactDb() : base("DefaultConnection")
        {

        }

        public DbSet<Contact> Contacts { get; set; }

        public void Save()
        {
            SaveChanges();
        }

        public void Add(Contact c)
        {
            Contacts.Add(c);
        }

        public void Remove(Contact c)
        {
            Contacts.Remove(c);
        }


        IQueryable<Contact> IContactDataSource.Contacts 
        {
            get { return Contacts; }
        }


    }
}