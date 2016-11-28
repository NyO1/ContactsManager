using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
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


        IQueryable<Contact> IContactDataSource.Contacts 
        {
            get { return Contacts; }
        }
    }
}