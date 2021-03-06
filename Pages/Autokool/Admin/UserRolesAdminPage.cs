using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Facade.DrivingSchool.Factories;
using Autokool.Facade.DrivingSchool.ViewModels;
using Autokool.Pages.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Autokool.Pages.Autokool.Admin
{
    [Authorize(Roles = "SuperAdmin")]
    public sealed class UserRolesAdminPage : ViewPage<UserRolesAdminPage, IUserRolesRepo, UserRoles, UserRolesView, UserRolesData>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public List<UserRolesData> usersDataList { get; set; }
        public List<ManageUserRolesData> userRolesList { get; set; }

        public UserRolesAdminPage(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, IUserRolesRepo r) : base(r, "UserRoles")
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        protected override Uri pageUrl() => new Uri("/Administrator/UserRoles", UriKind.Relative);
        protected internal override UserRoles toObject(UserRolesView v) => new UserRolesViewFactory().Create(v);
        protected internal override UserRolesView toView(UserRoles o) => new UserRolesViewFactory().Create(o);
        protected override void createTableColumns() { }
        public override async Task<IActionResult> OnGetIndexAsync(string sortOrder,
            string id, string currentFilter, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue)
        {
            await UsersToList();
            SelectedId = id;
            await getList(sortOrder, currentFilter, searchString, pageIndex,
               fixedFilter, fixedValue).ConfigureAwait(true);
            return Page();
        }
        public async Task<IActionResult> OnGetManageAsync(string userId)
        {
            if (userId == null)
            {
                return Page();
            }
            await UserRolesToList(userId);
            return Page();
        }
        public async Task<IActionResult> OnPostManageAsync(string userId, List<bool> selected)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return Page();
            }
            var roles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, roles);
            await UserToRole(selected, user);
            return Redirect(IndexUrl.ToString());
        }
        private async Task UserToRole(List<bool> selected, ApplicationUser user)
        {
            switch (selected.Count)
            {
                case 1:
                    await _userManager.AddToRoleAsync(user, "Student");
                    break;
                case 2:
                    await _userManager.AddToRoleAsync(user, "Teacher");
                    break;
                case 3:
                    await _userManager.AddToRoleAsync(user, "Administrator");
                    break;
                case 4:
                    await _userManager.AddToRoleAsync(user, "SuperAdmin");
                    break;
            }//Ideaalne ei ole aga sellele kulus liiga palju aega ja ma ei saanud hakkama, lisaks ei toota filtreerimine
        }
        private async Task UserRolesToList(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            userRolesList = new List<ManageUserRolesData>();
            foreach (var role in _roleManager.Roles)
            {
                var manageUserRolesData = new ManageUserRolesData();
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
                userRolesList.Add(manageUserRolesData);
            }
        }
        private async Task UsersToList()
        {
            var users = await _userManager.Users.ToListAsync();
            usersDataList = new List<UserRolesData>();
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
        }
        private async Task<List<string>> GetUserRoles(ApplicationUser user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }
    }
}