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
    public sealed class ExamsStudentPage : ExamsBasePage<ExamsStudentPage>
    {
        public readonly UserManager<ApplicationUser> _userManager;
        public IRegisterExamRepo _registerRepo;
        public RegisterExam _registerExam;
        public ExamsStudentPage(UserManager<ApplicationUser> userManager, IExamRepo e,
            IExamTypeRepo et, IRegisterExamRepo r) : base(e, et) 
        {
            _registerRepo = r;
            _userManager = userManager;
        }
        protected override Uri pageUrl() => new Uri("/Student/Exams", UriKind.Relative);
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
            _registerExam = await _registerRepo.Get(currentUser.Id);
            SelectedId = id;
            await getList(sortOrder, currentFilter, searchString, pageIndex,
                fixedFilter, fixedValue).ConfigureAwait(true);
            return Page();
        }
        public override async Task<IActionResult> OnPostEditAsync(string sortOrder, string searchString, int pageIndex, string fixedFilter, string fixedValue, string Id)
        {
            var currentUser = await GetCurrentUserAsync(HttpContext);
            _registerExam = await _registerRepo.Get(currentUser.Id);
            await _registerRepo.Delete(_registerExam.ID);

            return Redirect(IndexUrl.ToString());
        }
        public async Task<IActionResult> OnPostRegisterAsync(string id)
        {
            var currentUser = await GetCurrentUserAsync(HttpContext);
            await _registerRepo.RegisterDataToUser(new RegisterExamData(), currentUser, _registerRepo,id);
            return Redirect(IndexUrl.ToString());
        }
    }
}