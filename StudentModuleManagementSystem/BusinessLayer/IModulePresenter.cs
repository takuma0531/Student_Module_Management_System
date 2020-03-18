using System;
using System.Collections.Generic;
using StudentModuleManagementSystem.DataAccessLayer;

namespace StudentModuleManagementSystem.BusinessLayer
{
    public interface IModulePresenter
    {
        List<Module> GetModules();

        Module GetModuleById(int id);

        void RegisterModule(Module module);

        void EditModule(Module module);

        void DeleteModule(int id);
    }
    

}
