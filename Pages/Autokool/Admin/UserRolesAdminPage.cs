using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Autokool.Domain;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Facade.DrivingSchool.Factories;
using Autokool.Facade.DrivingSchool.ViewModels;
using Autokool.Pages.Common;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Autokool.Pages.Autokool.Admin
{
    public class UserRolesAdminPage : ViewPage<UserRolesAdminPage, IUserRolesRepo, UserRoles, UserRolesView, UserRolesData>
        
    {
        public readonly UserManager<ApplicationUser> _userManager;
        public readonly RoleManager<IdentityRole> _roleManager;
        public List<ApplicationUser> users;
        public List<UserRolesData> usersData;
        public List<ManageUserRolesData> UserRolesList;
        public ManageUserRolesData manageUserRolesData;
        public IEnumerable<SelectListItem> ManageUserRolesList { get; set; }
        public IManageUserRolesRepo rolesRepo;

        public UserRolesAdminPage(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, IUserRolesRepo r, IManageUserRolesRepo m) : base(r, "UserRoles")
        {
            rolesRepo = m;
            _roleManager = roleManager;
            _userManager = userManager;
            
        }
        protected override Uri pageUrl() => new Uri("/Administrator/UserRoles", UriKind.Relative);
        protected internal override UserRoles toObject(UserRolesView v) => new UserRolesViewFactory().Create(v);
        protected internal override UserRolesView toView(UserRoles o) => new UserRolesViewFactory().Create(o);
        protected override void createTableColumns()
        {
            
        }
        public override async Task<IActionResult> OnGetIndexAsync(string sortOrder,
            string id, string currentFilter, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue, bool isRegistered)
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
            SelectedId = id;
            await getList(sortOrder, currentFilter, searchString, pageIndex,
               fixedFilter, fixedValue).ConfigureAwait(true);
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
            UserRolesList = new List<ManageUserRolesData>();
            
            foreach (var role in _roleManager.Roles)
            {
                manageUserRolesData = new ManageUserRolesData();
                manageUserRolesData.RoleId = role.Id;
                manageUserRolesData.RoleName = role.Name;
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    manageUserRolesData.Selected = true;
                }
                else
                {
                    manageUserRolesData.Selected = false;
                }
                UserRolesList.Add(manageUserRolesData);
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
