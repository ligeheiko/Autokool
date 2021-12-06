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
        public ApplicationUser applicationUser;
        public List<ApplicationUser> users;
        public UserRolesData userRolesData;
        public List<UserRolesData> usersDataList = new List<UserRolesData>();
        public List<ManageUserRolesData> UserRolesList = new List<ManageUserRolesData>();
        public ManageUserRolesData manageUserRolesData;

        public UserRolesAdminPage(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, IUserRolesRepo r) : base(r, "UserRoles")
        {
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
            foreach (ApplicationUser user in users)
            {
                var thisViewModel = new UserRolesData();
                thisViewModel.UserId = user.Id;
                thisViewModel.Email = user.Email;
                thisViewModel.FirstName = user.FirstName;
                thisViewModel.LastName = user.LastName;
                thisViewModel.Roles = await GetUserRoles(user);
                usersDataList.Add(thisViewModel);
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
        public async Task<IActionResult> OnGetManageAsync(string userId, List<ManageUserRolesData> model)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
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
            model = UserRolesList;
            return Page();
        }
        public async Task<IActionResult> OnPostManageAsync(List<ManageUserRolesData> model, string userId, List<bool> selected)
        {
            applicationUser = await _userManager.FindByIdAsync(userId);
            if (applicationUser == null)
            {
                return Page();
            }
            foreach (var role in _roleManager.Roles)
            {
                manageUserRolesData = new ManageUserRolesData();
                manageUserRolesData.RoleId = role.Id;
                manageUserRolesData.RoleName = role.Name;
                if (await _userManager.IsInRoleAsync(applicationUser, role.Name))
                {
                    manageUserRolesData.Selected = true;
                }
                else
                {
                    manageUserRolesData.Selected = false;
                }
                model.Add(manageUserRolesData);
            }
            UserRolesList = model;
            var roles = await _userManager.GetRolesAsync(applicationUser);
            var result = await _userManager.RemoveFromRolesAsync(applicationUser, roles);
            switch (selected.Count)
            {
                case 1:
                    await _userManager.AddToRoleAsync(applicationUser, "Student");
                    break;
                case 2:
                    await _userManager.AddToRoleAsync(applicationUser, "Teacher");
                    break;
                case 3:
                    await _userManager.AddToRoleAsync(applicationUser, "Administrator");
                    break;
                case 4:
                    await _userManager.AddToRoleAsync(applicationUser, "SuperAdmin");
                    break;
            }//Ideaalne ei ole aga sellele kulus liiga palju aega ja ma ei saanud hakkama
            return Redirect(IndexUrl.ToString());
        }
    }
}
