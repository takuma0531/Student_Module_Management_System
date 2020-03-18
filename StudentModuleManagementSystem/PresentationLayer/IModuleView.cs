using System;
namespace StudentModuleManagementSystem.PresentationLayer
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
