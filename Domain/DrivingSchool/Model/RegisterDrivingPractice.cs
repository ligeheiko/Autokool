using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Repos;

namespace Autokool.Domain.DrivingSchool.Model
{
    public sealed class RegisterDrivingPractice : RegisterEntity<RegisterDrivingPracticeData>
    {
        public RegisterDrivingPractice(RegisterDrivingPracticeData d) : base(d) { }
        public string DrivingPracticeID => Data?.DrivingPracticeID ?? Unspecified;
        public string TeacherID => Data?.TeacherID ?? Unspecified;
        public DrivingPractice DrivingPractice => new GetFrom<IDrivingPracticeRepo, DrivingPractice>()?.ById(DrivingPracticeID);
        public Teacher Teacher => new GetFrom<ITeacherRepo, Teacher>()?.ById(TeacherID);
    }
}