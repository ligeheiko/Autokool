﻿using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;

namespace Autokool.Domain
{
    public sealed class Administrator : PersonEntity<AdministratorData>
    {
        public Administrator(AdministratorData d) : base(d) { }
    }
}
