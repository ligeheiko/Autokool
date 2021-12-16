using System.ComponentModel;

namespace Autokool.Facade.Common
{
    public abstract class RegisterView : BaseView
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public bool IsRegistered { get; set; }
    }
}