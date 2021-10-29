﻿using Autokool.Facade.Common;
using System.ComponentModel.DataAnnotations;

namespace Facade.Common
{
    public abstract class PersonView : DateView
    {
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Phone number")]
        public string PhoneNr { get; set; }
    }
}