using Autokool.Data.Common;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Pages.Autokool.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Autokool.Pages.Autokool.Admin
{
    [Authorize(Roles = "Administrator")]
    public class TeachersAdminPage : TeachersBasePage<TeachersAdminPage>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public ApplicationUser applicationUser;
        public string UserId;

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
                Id = Item.ID,
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
        public override Task<IActionResult> OnGetEditAsync(string id, string sortOrder, string searchString, int pageIndex, string fixedFilter, string fixedValue)
        {
            UserId = id;
            return base.OnGetEditAsync(id, sortOrder, searchString, pageIndex, fixedFilter, fixedValue);
        }
        public override async Task<IActionResult> OnPostEditAsync(string sortOrder, string searchString, int pageIndex, string fixedFilter, string fixedValue, string id)
        {
            var oldUser = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(oldUser);
            await updateObject(sortOrder, searchString, pageIndex, fixedFilter, fixedValue).ConfigureAwait(true);

            var user = new ApplicationUser
            {
                Id = Item.ID,
                UserName = Item.FirstName,
                Email = Item.Email,
                FirstName = Item.FirstName,
                LastName = Item.Name
            };
            if (user == null)
            {
                return NotFound();
            }
            var result = await _userManager.CreateAsync(user, user.FirstName.ToString() + user.LastName.ToString() + "1'");
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Roles.Teacher.ToString());
            }
            return Redirect(IndexUrl.ToString());
        }
        public override async Task<IActionResult> OnPostDeleteAsync(string id, string sortOrder, string searchString, int pageIndex, string fixedFilter, string fixedValue)
        {
            await deleteObject(id, sortOrder, searchString, pageIndex, fixedFilter, fixedValue).ConfigureAwait(true);
            var userToDelete = await _userManager.FindByIdAsync(id);
            if (userToDelete == null)
            {
                return NotFound();
            }
            await _userManager.DeleteAsync(userToDelete);
            return Redirect(IndexUrl.ToString());
        }
    }
}