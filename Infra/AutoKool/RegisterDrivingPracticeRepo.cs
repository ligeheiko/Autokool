using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Infra.Common;

namespace Autokool.Infra.AutoKool
{
    public sealed class RegisterDrivingPracticeRepo : UniqueEntitiesRepo<RegisterDrivingPractice, RegisterDrivingPracticeData>,
       IRegisterDrivingPracticeRepo
    {
        public RegisterDrivingPracticeRepo(ApplicationDbContext c) : base(c, c.RegisterDrivingPractices) { }
        protected internal override RegisterDrivingPractice toDomainObject(RegisterDrivingPracticeData d)
        => new RegisterDrivingPractice(d);
    }
}