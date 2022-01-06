using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using System.Threading.Tasks;

namespace Autokool.Domain.DrivingSchool.Repos
{
    public interface IRegisterExamRepo : IRepo<RegisterExam>
    {
        public Task RegisterDataToUser(RegisterExamData rData, ApplicationUser currentUser, IRegisterExamRepo r, string id);
    }
}