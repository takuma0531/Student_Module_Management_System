using System;
using System.Collections.Generic;

namespace StudentModuleManagementSystem.DataAccessLayer
{
    public partial class StudentModule
    {
        public int StudentId { get; set; }
        public int ModuleId { get; set; }

        public virtual Module Module { get; set; }
        public virtual Student Student { get; set; }
    }
}
