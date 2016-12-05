using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace contactsManager.Web.Models
{
    public class CreateContactViewModel
    {
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(35)]
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.ImageUrl)]
        public string PhotoUrl { get; set; }

        public bool Pref { get; set; }

        
    }
}