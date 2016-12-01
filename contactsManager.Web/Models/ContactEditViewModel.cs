using System.ComponentModel.DataAnnotations;

namespace contactsManager.Web.Models
{
    public class ContactEditViewModel
    {
        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.ImageUrl)]
        public string PhotoUrl { get; set; }

        public bool Pref { get; set; }
    }
}