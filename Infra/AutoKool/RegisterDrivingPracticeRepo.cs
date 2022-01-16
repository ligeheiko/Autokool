using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Infra.Common;
using System.Threading.Tasks;

namespace Autokool.Infra.AutoKool
{
    public sealed class RegisterDrivingPracticeRepo : RegisterRepo<RegisterDrivingPractice, RegisterDrivingPracticeData, IRegisterDrivingPracticeRepo>,
       IRegisterDrivingPracticeRepo
    {
        public RegisterDrivingPracticeRepo(ApplicationDbContext c) : base(c, c.RegisterDrivingPractices) { }
        protected internal override RegisterDrivingPractice toDomainObject(RegisterDrivingPracticeData d) => new (d);
        public override async Task RegisterDataToUser(RegisterDrivingPracticeData rData, ApplicationUser currentUser, IRegisterDrivingPracticeRepo r, string id)
        {
            rData.DrivingPracticeID = id;
            await base.RegisterDataToUser(rData, currentUser, r, id);
        }
    }
}