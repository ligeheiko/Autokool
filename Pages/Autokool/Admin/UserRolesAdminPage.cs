using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autokool.Pages.Autokool.Admin
{
    public class UserRolesAdminPage : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public List<ApplicationUser> users;
        public List<UserRolesData> usersData;
        public List<ManageUserRolesData> model;
        public ManageUserRolesData manageUserRolesData;

        public UserRolesAdminPage(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> OnGetIndexAsync()
        {
            users = await _userManager.Users.ToListAsync();
            usersData = new List<UserRolesData>();
            foreach (ApplicationUser user in users)
            {
                var thisViewModel = new UserRolesData();
                thisViewModel.UserId = user.Id;
                thisViewModel.Email = user.Email;
                thisViewModel.FirstName = user.FirstName;
                thisViewModel.LastName = user.LastName;
                thisViewModel.Roles = await GetUserRoles(user);
                usersData.Add(thisViewModel);
            }
            return Page();
        }
        private async Task<List<string>> GetUserRoles(ApplicationUser user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }
        public async Task<IActionResult> OnGetManageAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            model = new List<ManageUserRolesData>();
            foreach (var role in _roleManager.Roles)
            {
                manageUserRolesData = new ManageUserRolesData
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    manageUserRolesData.Selected = true;
                }
                else
                {
                    manageUserRolesData.Selected = false;
                }
                model.Add(manageUserRolesData);
            }
            return Page();
        }
        public async Task<IActionResult> OnPostManageAsync(List<ManageUserRolesData> model, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return Page();
            }
            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return Page();
            }
            result = await _userManager.AddToRolesAsync(user, model.Where(x => x.Selected).Select(y => y.RoleName));
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return Page();
            }
            return RedirectToAction("Index");
        }
    }
}
