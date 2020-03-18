using System;
using StudentModuleManagementSystem.DataAccessLayer;

namespace StudentModuleManagementSystem.BusinessLayer
{
    public interface IOptionSelector
    {
        void PressKey();

        string SelectStringOption();

        int SelectIntOption();

        Student SelectWayOfChoosingStudent();
    }
}
