using System.ComponentModel.DataAnnotations;

namespace Autokool.Facade.Common
{
    public abstract class PersonView : DateView
    {
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(50)]
        [Required]
        [EmailAddress]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [StringLength(50)]
        [Display(Name = "Phone number")]
        public string PhoneNr { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }
    }
}
