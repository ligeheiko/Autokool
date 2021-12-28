using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Autokool.Facade.Common
{
    public abstract class PersonView : DateView
    {
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [DisplayName("Last Name")]
        [Required]
        public new string Name { get; set; }

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