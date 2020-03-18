using System;
using System.Collections.Generic;

namespace StudentModuleManagementSystem.DataAccessLayer
{
    public partial class Module
    {
        public Module()
        {
            StudentModule = new HashSet<StudentModule>();
        }

        public int ModuleId { get; set; }
        public string ModuleName { get; set; }

        public virtual ICollection<StudentModule> StudentModule { get; set; }
    }
}
