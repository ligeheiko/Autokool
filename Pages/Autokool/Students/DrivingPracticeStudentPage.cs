using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Pages.Autokool.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Autokool.Pages.Autokool.Students
{
    [Authorize(Roles = "Student")]
    public sealed class DrivingPracticeStudentPage : DrivingPracticeBasePage<DrivingPracticeStudentPage>
    {
        public IRegisterDrivingPracticeRepo _registerRepo;
        public readonly UserManager<ApplicationUser> _userManager;
        public RegisterDrivingPractice _registerDrivingPractice;

        public DrivingPracticeStudentPage(UserManager<ApplicationUser> userManager, 
            IDrivingPracticeRepo d, ITeacherRepo t, 
            IRegisterDrivingPracticeRepo r) : base(d, t) 
        {
            _registerRepo = r;
            _userManager = userManager;
        }
        protected override Uri pageUrl() => new Uri("/Student/DrivingPractices", UriKind.Relative);
        public async Task<ApplicationUser> GetCurrentUserAsync(HttpContext c) => await _userManager.GetUserAsync(c.User);
        public override async Task<IActionResult> OnGetIndexAsync(string sortOrder,
           string id, string currentFilter, string searchString, int? pageIndex,
           string fixedFilter, string fixedValue)
        {
            var currentUser = await GetCurrentUserAsync(HttpContext);
            if (currentUser == null)
            {
                return Page();
            }
            _registerDrivingPractice = await _registerRepo.Get(currentUser.Id);
            SelectedId = id;
            await getList(sortOrder, currentFilter, searchString, pageIndex,
                fixedFilter, fixedValue).ConfigureAwait(true);
            return Page();
        }
        public override async Task<IActionResult> OnPostEditAsync(string sortOrder, string searchString, 
            int pageIndex, string fixedFilter, string fixedValue, string Id)
        {
            var currentUser = await GetCurrentUserAsync(HttpContext);
            if (currentUser == null)
            {
                return Page();
            }
            _registerDrivingPractice = await _registerRepo.Get(currentUser.Id);
            await _registerRepo.Delete(_registerDrivingPractice.ID);

            return Redirect(IndexUrl.ToString());
        }
        public async Task<IActionResult> OnPostRegisterAsync(string id, string sortOrder, string searchString,
           int pageIndex,
           string fixedFilter, string fixedValue)
        {
            var currentUser = await GetCurrentUserAsync(HttpContext);
            if (currentUser == null)
            {
                return Page();
            }
            var obj = db.GetById(ItemId);
            var rData = new RegisterDrivingPracticeData();
            rData.TeacherID = (obj as DrivingPractice).TeacherID;
            await _registerRepo.RegisterDataToUser(rData, currentUser, _registerRepo, id);
            return Redirect(IndexUrl.ToString());
        }
    }
}