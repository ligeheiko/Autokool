using Autokool.Aids.Constants;
using Autokool.Data.Common;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Pages.Autokool.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Autokool.Pages.Autokool.Admin
{
    [Authorize(Roles = "Administrator")]
    public sealed class TeachersAdminPage : TeachersBasePage<TeachersAdminPage>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public string UserId { get; set; }
        public ApplicationUser user { get; set; }

        public TeachersAdminPage(ITeacherRepo t, UserManager<ApplicationUser> userManager) : base(t) 
        {
            _userManager = userManager;
        }
        public override async Task<IActionResult> OnPostCreateAsync(string sortOrder, string searchString, int? pageIndex, string fixedFilter, string fixedValue)
        {
            if (!await addObject(sortOrder, searchString, pageIndex, fixedFilter, fixedValue)
               .ConfigureAwait(true)) return Page();
            await CreateAdded();
            user = GetApplicationUser();
            await AddUserToTeacherRole(user);
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
            await CreateAdded();
            var user = GetApplicationUser();
            if (user == null)
            {
                return NotFound();
            }
            await AddUserToTeacherRole(user);
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
        private async Task CreateAdded()
        {
            var teacher = await db.Get(Item?.ID ?? Word.Unspecified);
            await db.CreateValidFrom(teacher);
        }
        private ApplicationUser GetApplicationUser()
        {
            user = new ApplicationUser
            {
                Id = Item?.ID ?? "Unspecified",
                UserName = Item?.FirstName ?? "Unspecified",
                Email = Item?.Email ?? "Unspecified",
                FirstName = Item?.FirstName ?? "Unspecified",
                LastName = Item?.Name ?? "Unspecified",
            };
            return user;
        }
        private async Task AddUserToTeacherRole(ApplicationUser user)
        {
            if (user == null || user.Id == "Unspecified")
            {
                return;
            }
            var result = await _userManager.CreateAsync(user, user.FirstName.ToString() + user.LastName.ToString() + "1'");
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Roles.Teacher.ToString());
            }
        }
    }
}