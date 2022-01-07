using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Autokool.Domain.DrivingSchool.Repos
{
    public interface IRegisterCourseRepo : IRepo<RegisterCourse>
    {
        public Task RegisterDataToUser(RegisterCourseData rData, ApplicationUser currentUser, IRegisterCourseRepo r, string id);
    }
}