using System;
using System.Collections.Generic;
using StudentModuleManagementSystem.DataAccessLayer;

namespace StudentModuleManagementSystem.BusinessLayer
{
    public class Validation : IValidation
    {
        private readonly IStudentModulePresenter _studentModulePresenter;
        private readonly IStudentPresenter _studentPresenter;
        private readonly IModulePresenter _modulePresenter;

        bool existence = false;


        public Validation(IStudentModulePresenter studentModulePresenter,
                          IStudentPresenter studentPresenter,
                          IModulePresenter modulePresenter)
        {
            _studentModulePresenter = studentModulePresenter;
            _studentPresenter = studentPresenter;
            _modulePresenter = modulePresenter;
        }

        public bool CheckStudentExists(int studentId)
        {
            Student student = _studentPresenter.GetStudentById(studentId);
            if (student != null)
            {
                existence = true;
            }
            else
            {
                existence = false;
            }

            return existence;
        }

        public bool CheckModuleExists(int moduleId)
        {
            Module module = _modulePresenter.GetModuleById(moduleId);
            if (module != null)
            {
                existence = true;
            }
            else
            {
                existence = false;
            }

            return existence;
        }

        public bool CheckStudentModuleExistsByStudentId(int studentId)
        {
            List<StudentModule> studentModules = _studentModulePresenter.GetStudentModuleByStudentId(studentId);
            if (studentModules.Count != 0)
            {
                existence = true;
            }
            else
            {
                existence = false;
            }

            return existence;
        }

        public bool CheckStudentModuleExistsByModuleId(int moduleId)
        {
            List<StudentModule> studentModules = _studentModulePresenter.GetStudentModuleByModuleId(moduleId);
            if (studentModules != null)
            {
                existence = true;
            }
            else
            {
                existence = false;
            }

            return existence;
        }
    }
}
