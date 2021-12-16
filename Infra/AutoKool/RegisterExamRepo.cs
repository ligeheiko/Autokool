using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Infra.Common;

namespace Autokool.Infra.AutoKool
{
    public sealed class RegisterExamRepo : UniqueEntitiesRepo<RegisterExam, RegisterExamData>,
       IRegisterExamRepo
    {
        public RegisterExamRepo(ApplicationDbContext c) : base(c, c.RegisterExams) { }
        protected internal override RegisterExam toDomainObject(RegisterExamData d)
        => new RegisterExam(d);
    }
}