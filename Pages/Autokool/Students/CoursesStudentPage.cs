using Autokool.Data.Common;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Pages.Autokool.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Autokool.Pages.Autokool.Students
{
    [Authorize(Roles = "Student")]
    public class CoursesStudentPage : CoursesBasePage<CoursesStudentPage>
    {
        public readonly UserManager<ApplicationUser> _userManager;
        public ApplicationUser _applicationUser;
        public RegisterData registerData;
        public Register register1;
        public IRegisterRepo _registerRepo;

        public CoursesStudentPage(UserManager<ApplicationUser> userManager
            , ICourseRepo c, ICourseTypeRepo ct, IRegisterRepo r) : base(c, ct) 
        {
            _registerRepo = r;
            _userManager = userManager;
        }
        protected override Uri pageUrl() => new Uri("/Student/Courses", UriKind.Relative);
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        public override async Task<IActionResult> OnGetIndexAsync(string sortOrder,
           string id, string currentFilter, string searchString, int? pageIndex,
           string fixedFilter, string fixedValue, bool isRegistered)
        {
            var currentUser = await GetCurrentUserAsync();
            register1 = await _registerRepo.Get(currentUser.Id);
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
            await getObject(id, sortOrder, searchString, pageIndex, fixedFilter, fixedValue).ConfigureAwait(true);
            register = true;
            setIsRegistered(register);
            return Page();
        }
        public override async Task<IActionResult> OnPostEditAsync(string sortOrder, string searchString, int pageIndex, string fixedFilter, string fixedValue, string userId = null)
        {
            var currentUser = await GetCurrentUserAsync();
            register1 = await _registerRepo.Get(currentUser.Id);
            register1.Data.IsRegisteredCourse = false;
            await _registerRepo.Update(register1);

            return Redirect(IndexUrl.ToString());
        }
        public async Task<IActionResult> OnPostRegisterAsync(string id, string sortOrder, string searchString,
           int pageIndex,
           string fixedFilter, string fixedValue, bool register)
        {
            var currentUser = await GetCurrentUserAsync();
            registerData = new RegisterData();
            registerData.ID = currentUser.Id;
            registerData.CourseID = id;
            registerData.UserId = currentUser.Id;
            registerData.IsRegisteredCourse = true;
            var reg = toObject(registerData);
            await _registerRepo.Add(reg).ConfigureAwait(true);
            return Redirect(IndexUrl.ToString());
        }
        protected internal Register toObject(RegisterData d) => new Register(d);
    }
}