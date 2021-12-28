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
    public sealed class DrivingPracticeStudentPage : DrivingPracticeBasePage<DrivingPracticeStudentPage>
    {
        public IRegisterDrivingPracticeRepo _registerRepo;
        public readonly UserManager<ApplicationUser> _userManager;
        public RegisterDrivingPracticeData _registerDrivingPracticeData;
        public RegisterDrivingPractice _registerDrivingPractice;

        public DrivingPracticeStudentPage(UserManager<ApplicationUser> userManager, 
            IDrivingPracticeRepo d, ITeacherRepo t, 
            IRegisterDrivingPracticeRepo r) : base(d, t) 
        {
            _registerRepo = r;
            _userManager = userManager;
        }
        protected override Uri pageUrl() => new Uri("/Student/DrivingPractices", UriKind.Relative);
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        public override async Task<IActionResult> OnGetIndexAsync(string sortOrder,
           string id, string currentFilter, string searchString, int? pageIndex,
           string fixedFilter, string fixedValue)
        {
            var currentUser = await GetCurrentUserAsync();
            _registerDrivingPractice = await _registerRepo.Get(currentUser.Id);
            SelectedId = id;
            await getList(sortOrder, currentFilter, searchString, pageIndex,
                fixedFilter, fixedValue).ConfigureAwait(true);
            return Page();
        }
        public override async Task<IActionResult> OnPostEditAsync(string sortOrder, string searchString, int pageIndex, string fixedFilter, string fixedValue, string Id)
        {
            var currentUser = await GetCurrentUserAsync();
            _registerDrivingPractice = await _registerRepo.Get(currentUser.Id);
            await _registerRepo.Delete(_registerDrivingPractice.ID);

            return Redirect(IndexUrl.ToString());
        }
        public async Task<IActionResult> OnPostRegisterAsync(string id, string sortOrder, string searchString,
           int pageIndex,
           string fixedFilter, string fixedValue)
        {
            var currentUser = await GetCurrentUserAsync();
            var obj = db.GetById(ItemId);
            _registerDrivingPracticeData = new RegisterDrivingPracticeData();
            _registerDrivingPracticeData.ID = currentUser.Id;
            _registerDrivingPracticeData.DrivingPracticeID = id;
            _registerDrivingPracticeData.UserId = currentUser.Id;
            _registerDrivingPracticeData.UserName = currentUser.UserName;
            _registerDrivingPracticeData.TeacherID = (obj as DrivingPractice).TeacherID;
            _registerDrivingPracticeData.IsRegistered = true;

            var reg = toObject(_registerDrivingPracticeData);
            await _registerRepo.Add(reg).ConfigureAwait(true);
            return Redirect(IndexUrl.ToString());
        }
        public RegisterDrivingPractice toObject(RegisterDrivingPracticeData d) => new RegisterDrivingPractice(d);
    }
}