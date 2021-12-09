using Microsoft.AspNetCore.Identity;

namespace Autokool.Data.Common
{
    public sealed class ApplicationUser : IdentityUser 
    {  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] ProfilePicture { get; set; }
    }
}