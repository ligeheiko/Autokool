using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Autokool.Facade.Common
{
    public abstract class PersonView : DateView
    {
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [StringLength(50)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [StringLength(50)]
        [Required]
        [EmailAddress]
        [DisplayName("Email address")]
        public string Email { get; set; }

        [StringLength(50)]
        [DisplayName("Phone number")]
        public string PhoneNr { get; set; }

        [DisplayName("Full Name")]
        public string FullName { get; set; }
    }
}
