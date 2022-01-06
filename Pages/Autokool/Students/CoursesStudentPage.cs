using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
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
    public sealed class CoursesStudentPage : CoursesBasePage<CoursesStudentPage>
    {
        public readonly UserManager<ApplicationUser> _userManager;
        public RegisterCourse _registerCourse;
        public IRegisterCourseRepo _registerRepo;

        public CoursesStudentPage(UserManager<ApplicationUser> userManager
            , ICourseRepo c, ICourseTypeRepo ct, IRegisterCourseRepo r) : base(c, ct) 
        {
            _registerRepo = r;
            _userManager = userManager;
        }
        protected override Uri pageUrl() => new Uri("/Student/Courses", UriKind.Relative);
        public Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext?.User);
        public override async Task<IActionResult> OnGetIndexAsync(string sortOrder,
           string id, string currentFilter, string searchString, int? pageIndex,
           string fixedFilter, string fixedValue)
        {
            var currentUser = await GetCurrentUserAsync();
            if (currentUser == null)
            {
                return Page();
            }
            _registerCourse = await _registerRepo.Get(currentUser.Id);
            SelectedId = id;
            await getList(sortOrder, currentFilter, searchString, pageIndex,
                fixedFilter, fixedValue).ConfigureAwait(true);
            return Page();
        }
        public override async Task<IActionResult> OnPostEditAsync(string sortOrder, string searchString, int pageIndex, string fixedFilter, string fixedValue, string Id)
        {
            var currentUser = await GetCurrentUserAsync();
            _registerCourse = await _registerRepo.Get(currentUser.Id);
            var regCourse = await _registerRepo.Get(currentUser.Id);
            await _registerRepo.Delete(regCourse.ID);
            return Redirect(IndexUrl.ToString());
        }
        public async Task<IActionResult> OnPostRegisterAsync(string id, string sortOrder, string searchString,
           int pageIndex,
           string fixedFilter, string fixedValue)
        {
            var currentUser = await GetCurrentUserAsync();
            await _registerRepo.RegisterDataToUser(new RegisterCourseData(), currentUser, _registerRepo, id);
            return Redirect(IndexUrl.ToString());
        }
    }
}