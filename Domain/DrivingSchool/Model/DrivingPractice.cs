using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Repos;

namespace Autokool.Domain.DrivingSchool.Model
{
    public class DrivingPractice : DateEntity<DrivingPracticeData>
    {
        public DrivingPractice(DrivingPracticeData d) : base(d) { }
        public string TeacherID => Data?.TeacherID ?? Unspecified;
        public Teacher Teacher => new GetFrom<ITeacherRepo, Teacher>().ById(TeacherID);
    }
}