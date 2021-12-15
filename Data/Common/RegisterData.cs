
namespace Autokool.Data.Common
{
    public class RegisterData : BaseData
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string CourseID { get; set; }
        public bool IsRegisteredCourse { get; set; }
    }
}