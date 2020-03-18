using System;
namespace StudentModuleManagementSystem.BusinessLayer
{
    public interface IValidation
    {
        bool CheckStudentExists(int studentId);

        bool CheckModuleExists(int moduleId);

        bool CheckStudentModuleExistsByStudentId(int studentId);

        bool CheckStudentModuleExistsByModuleId(int moduleId);
    }
}
