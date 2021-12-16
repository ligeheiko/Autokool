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
    public class ExamsStudentPage : ExamsBasePage<ExamsStudentPage>
    {
        public readonly UserManager<ApplicationUser> _userManager;
        public IRegisterExamRepo _registerRepo;
        public RegisterExam _registerExam;
        public RegisterExamData _registerExamData;
        public ExamsStudentPage(UserManager<ApplicationUser> userManager, IExamRepo e,
            IExamTypeRepo et, IRegisterExamRepo r) : base(e, et) 
        {
            _registerRepo = r;
            _userManager = userManager;
        }
        protected override Uri pageUrl() => new Uri("/Student/Exams", UriKind.Relative);
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        public override async Task<IActionResult> OnGetIndexAsync(string sortOrder,
           string id, string currentFilter, string searchString, int? pageIndex,
           string fixedFilter, string fixedValue, bool isRegistered)
        {
            var currentUser = await GetCurrentUserAsync();
            _registerExam = await _registerRepo.Get(currentUser.Id);
            SelectedId = id;
            await getList(sortOrder, currentFilter, searchString, pageIndex,
                fixedFilter, fixedValue).ConfigureAwait(true);
            return Page();
        }

        //public override async Task<IActionResult> OnGetDetailsAsync(string id, string sortOrder, string searchString,
        //   int pageIndex,
        //   string fixedFilter, string fixedValue, bool register)
        //{
        //    await getObject(id, sortOrder, searchString, pageIndex, fixedFilter, fixedValue).ConfigureAwait(true);
        //    register = true;
        //    setIsRegistered(register);
        //    return Page();
        //    //TODO registreerimis nupule vajutades saab admin vaadata kes on registreerinud
        //}
        public override async Task<IActionResult> OnPostEditAsync(string sortOrder, string searchString, int pageIndex, string fixedFilter, string fixedValue, string Id)
        {
            var currentUser = await GetCurrentUserAsync();
            _registerExam = await _registerRepo.Get(currentUser.Id);
            await _registerRepo.Delete(_registerExam.ID);

            return Redirect(IndexUrl.ToString());
        }
        public async Task<IActionResult> OnPostRegisterAsync(string id, string sortOrder, string searchString,
           int pageIndex,
           string fixedFilter, string fixedValue, bool register)
        {
            var currentUser = await GetCurrentUserAsync();
            _registerExamData = new RegisterExamData();
            _registerExamData.ID = currentUser.Id;
            _registerExamData.ExamID = id;
            _registerExamData.UserId = currentUser.Id;
            _registerExamData.UserName = currentUser.UserName;
            _registerExamData.IsRegisteredCourse = true;
            var reg = toObject(_registerExamData);
            await _registerRepo.Add(reg).ConfigureAwait(true);
            return Redirect(IndexUrl.ToString());
        }
        protected internal RegisterExam toObject(RegisterExamData d) => new RegisterExam(d);
    }
}
