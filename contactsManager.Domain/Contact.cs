using System.ComponentModel;

namespace contactsManager.Domain
{
    public class Contact
    {
        
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string Email { get; set; }
        public virtual string PhotoUrl { get; set; }

        public virtual bool Pref { get; set; }


      

    }
}
