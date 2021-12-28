using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "SuperAdmin")]
    public sealed class RoleManagerAdminPage : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public List<IdentityRole> identityRoles;
        public RoleManagerAdminPage(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task OnGetIndexAsync()
        {
            identityRoles = await _roleManager.Roles.ToListAsync();
        }
        //public async Task<IActionResult> OnPostCreateAsync(string roleName)
        //{
        //    if (roleName != null)
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole(roleName.Trim()));
        //    }
        //    identityRoles = await _roleManager.Roles.ToListAsync();
        //    return Page();
        //}
    }
}
