using Facade.Common;
using System.ComponentModel.DataAnnotations;

namespace Autokool.Facade.Common
{
    public abstract class NamedView : BaseView
    {
        [Required]
        public string Name { get; set; }
    }
}
