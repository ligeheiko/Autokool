using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using System.Threading.Tasks;

namespace Autokool.Domain.DrivingSchool.Repos
{
    public interface IRegisterDrivingPracticeRepo : IRepo<RegisterDrivingPractice>
    {
        public Task RegisterDataToUser(RegisterDrivingPracticeData rData, ApplicationUser currentUser, IRegisterDrivingPracticeRepo r, string id);
    }
}