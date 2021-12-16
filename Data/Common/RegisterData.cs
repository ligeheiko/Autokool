
namespace Autokool.Data.Common
{
    public abstract class RegisterData : BaseData
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public bool IsRegistered { get; set; }
    }
}