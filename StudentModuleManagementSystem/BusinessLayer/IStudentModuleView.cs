using System;
namespace StudentModuleManagementSystem.BusinessLayer
{
    public interface IStudentModuleView
    {
        void ViewStudentModuleByStudentId();

        void ViewStudentModuleByModuleId();

        void AssignStudentToModule();

        void DeleteStudentModuleOnePair();
    }
}
