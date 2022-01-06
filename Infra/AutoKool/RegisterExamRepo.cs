using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Infra.Common;
using System.Threading.Tasks;

namespace Autokool.Infra.AutoKool
{
    public sealed class RegisterExamRepo : RegisterRepo<RegisterExam, RegisterExamData, IRegisterExamRepo>,
        IRegisterExamRepo
    {
        public RegisterExamRepo(ApplicationDbContext c) : base(c, c.RegisterExams) { }
        protected internal override RegisterExam toDomainObject(RegisterExamData d)
        => new RegisterExam(d);
        public override async Task RegisterDataToUser(RegisterExamData rData, ApplicationUser currentUser, IRegisterExamRepo r, string id)
        {
            rData.ExamID = id;
            await base.RegisterDataToUser(rData, currentUser, r, id);
        }
    }
}