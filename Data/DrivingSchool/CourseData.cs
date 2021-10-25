using Autokool.Data.Common;

namespace Autokool.Data.DrivingSchool
{
    public sealed class CourseData : DateData
    {
        public string Location { get; set; }
        public string CourseTypeID { get; set; }

        //public List<CourseType> CourseType { get; set; }
    }
}
