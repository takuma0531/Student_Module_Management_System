using System;
using System.Collections.Generic;
using StudentModuleManagementSystem.DataAccessLayer;

namespace StudentModuleManagementSystem.BusinessLayer
{
    public interface IModuleView
    {
        string InputModuleName();

        List<Module> ViewModules();

        void RegisterModule();

        void EditModule();

        void DeleteModule();
    }
}
