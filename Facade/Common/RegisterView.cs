using Autokool.Facade.Common;
using System.ComponentModel;

namespace Autokool.Facade.DrivingSchool.ViewModels
{
    public abstract class RegisterView : BaseView
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public bool IsRegisteredCourse { get; set; }
    }
}