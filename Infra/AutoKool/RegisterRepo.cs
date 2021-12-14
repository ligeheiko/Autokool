using Autokool.Data.Common;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Infra.Common;

namespace Autokool.Infra.AutoKool
{
    public sealed class RegisterRepo : UniqueEntitiesRepo<Register, RegisterData>,
       IRegisterRepo
    {
        public RegisterRepo(ApplicationDbContext c) : base(c, c.RegisterDatas) { }
        protected internal override Register toDomainObject(RegisterData d)
        => new Register(d);
    }
}