using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Facade.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autokool.Facade.DrivingSchool
{
    public sealed class AdministratorViewFactory : AbstractViewFactory<AdministratorData, Administrator, AdministratorView>
    {
        protected internal override Administrator toObject(AdministratorData d) => new Administrator(d);
    }
}
