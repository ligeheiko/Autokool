using Autokool.Data.Common;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Pages.Autokool.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Autokool.Pages.Autokool.Admin
{
    [Authorize(Roles = "Teacher, Administrator")]
    public class TeachersAdminPage : TeachersBasePage<TeachersAdminPage>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public TeachersAdminPage(ITeacherRepo t/*, IStudentRepo s*/, UserManager<ApplicationUser> userManager) : base(t/*, s*/) 
        {
            _userManager = userManager;
        }

        public override async Task<IActionResult> OnPostCreateAsync(string sortOrder, string searchString, int? pageIndex, string fixedFilter, string fixedValue)
        {
            if (!await addObject(sortOrder, searchString, pageIndex, fixedFilter, fixedValue)
               .ConfigureAwait(true)) return Page();
            var user = new ApplicationUser
            {
                UserName = Item.FirstName,
                Email = Item.Email,
                FirstName = Item.FirstName,
                LastName = Item.Name
            };
            var result = await _userManager.CreateAsync(user, user.FirstName.ToString() + user.LastName.ToString() + "1'");
            if (result.Succeeded)
            {
                 await _userManager.AddToRoleAsync(user, Roles.Teacher.ToString());
            }
            return Redirect(IndexUrl.ToString());
        }
    }
}
