using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contactsManager.Domain
{
    public interface IContactDataSource
    {
        IQueryable<Contact> Contacts { get; }

        void Save();

        void Add(Contact c);
    }




    
}
