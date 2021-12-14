using Autokool.Data.Common;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Infra;
using Autokool.Infra.AutoKool;
using Autokool.Pages.Autokool.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Autokool.Pages.Autokool.Students
{
    [Authorize(Roles = "Student")]
    public class CoursesStudentPage : CoursesBasePage<CoursesStudentPage>
    {
        public readonly UserManager<ApplicationUser> _userManager;
        public RegisterData registerData;
        public ApplicationDbContext _context;
        public IRegisterRepo _registerRepo;

        public CoursesStudentPage(ApplicationDbContext context, UserManager<ApplicationUser> userManager
            , ICourseRepo c, ICourseTypeRepo ct, IRegisterRepo r) : base(c, ct) 
        {
            _registerRepo = r;
            _context = context;
            _userManager = userManager;
        }
        protected override Uri pageUrl() => new Uri("/Student/Courses", UriKind.Relative);
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        public override async Task<IActionResult> OnGetIndexAsync(string sortOrder,
           string id, string currentFilter, string searchString, int? pageIndex,
           string fixedFilter, string fixedValue, bool isRegistered)
        {
            
            getRegistered();
            SelectedId = id;
            setIsRegistered(isRegistered);
            await getList(sortOrder, currentFilter, searchString, pageIndex,
                fixedFilter, fixedValue).ConfigureAwait(true);
            return Page();
        }

        public override async Task<IActionResult> OnGetDetailsAsync(string id, string sortOrder, string searchString,
           int pageIndex,
           string fixedFilter, string fixedValue, bool register)
        {
            var Currentuser = await GetCurrentUserAsync();
            var regData = new RegisterData();
            regData.CourseID = id;
            regData.UserId = Currentuser.Id;
            await getObject(id, sortOrder, searchString, pageIndex, fixedFilter, fixedValue).ConfigureAwait(true);
            register = true;
            setIsRegistered(register);
            return Page();
            //TODO registreerimis nupule vajutades saab admin vaadata kes on registreerinud
        }
        public async Task<IActionResult> OnPostRegisterAsync(string id, string sortOrder, string searchString,
           int pageIndex,
           string fixedFilter, string fixedValue, bool register)
        {
            var Currentuser = await GetCurrentUserAsync();
            var regData = new RegisterData();
            regData.CourseID = Item.ID;
            regData.UserId = Currentuser.Id;
            regData.IsRegisteredCourse = true;
            var reg =  toObject(regData);
            await _registerRepo.Add(reg).ConfigureAwait(true);
            return Redirect(IndexUrl.ToString());
        }
        protected internal Register toObject(RegisterData d) => new Register(d);
    }
}
