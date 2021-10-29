﻿using Autokool.Data.Common;

namespace Autokool.Data.DrivingSchool
{
    public sealed class RoleTypeData : BaseData
    {
        public string AdministratorID{ get; set; }
        public string StudentID { get; set; }
        public string TeacherID { get; set; }
        //ei ole kindel kas see on vajalik voi pigem enum teha
    }
}