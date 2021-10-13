using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;

namespace Autokool.Domain
{
    public sealed class Course : BaseEntity<CourseData>
    {
        public string Location => Data.Location;
        public string CourseTypeID => Data.CourseTypeID;
        //public CourseType CourseType => GetRepo.Instance<ICourseTypeRepo>().GetByID(data.CourseTypeID);

    }
}
