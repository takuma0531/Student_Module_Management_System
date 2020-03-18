using System;
namespace StudentModuleManagementSystem.BusinessLayer
{
    public interface IModuleView
    {
        string InputModuleName();

        void ViewModules();

        void RegisterModule();

        void EditModule();

        void DeleteModule();
    }
}
