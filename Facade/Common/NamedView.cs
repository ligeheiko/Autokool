using System.ComponentModel.DataAnnotations;

namespace Autokool.Facade.Common
{
    public abstract class NamedView : BaseView
    {
        public string Name { get; set; }
    }
}
