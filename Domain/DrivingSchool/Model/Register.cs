using Autokool.Data.Common;
using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Repos;

namespace Autokool.Domain.DrivingSchool.Model
{
    public class Register : UniqueEntity<RegisterData>
    {
        public Register(RegisterData d) : base(d) { }
        public bool IsRegisteredCourse => Data?.IsRegisteredCourse ?? false;
        public string CourseID => Data?.CourseID ?? Unspecified;
        public string UserId => Data?.UserId ?? Unspecified;
        public Course Course => new GetFrom<ICourseRepo, Course>()?.ById(CourseID);
    }
}