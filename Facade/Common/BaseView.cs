using System;
using System.ComponentModel.DataAnnotations;

namespace Facade.Common
{
    public abstract class BaseView
    {
        public string ID { get; set; }
        public string GetId() => ID;
    }
}
