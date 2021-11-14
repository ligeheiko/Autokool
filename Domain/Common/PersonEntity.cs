using Autokool.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace Autokool.Domain.Common
{
    public abstract class PersonEntity<TData> : DateEntity<TData>
        where TData : PersonData, new()
    {
        protected PersonEntity(TData d = null) : base(d) { }

        public string FirstName => Data?.FirstName ?? Unspecified;
        public string LastName => Data?.LastName ?? Unspecified;
        public string Email => Data?.Email ?? Unspecified;
        public string PhoneNr => Data?.PhoneNr ?? Unspecified;


        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
    }
}
