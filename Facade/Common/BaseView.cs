using System;
using System.ComponentModel.DataAnnotations;

namespace Autokool.Facade.Common
{
    public abstract class BaseView
    {
        protected BaseView() => ID = Guid.NewGuid().ToString();
        public string ID { get; set; }
        public string GetId() => ID;
    }
}
