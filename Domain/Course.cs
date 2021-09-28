using Data;
using Domain.Common;

namespace Domain
{
    public class Course : BaseEntity<CourseData>
    {
        public string Location => Data.Location;
        public string CourseTypeID => Data.CourseTypeID;
        //public CourseType CourseType => GetRepo.Instance<ICourseTypeRepo>().GetByID(data.CourseTypeID);

    }
}
