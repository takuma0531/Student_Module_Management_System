using System;
using StudentModuleManagementSystem.DataAccessLayer;

namespace StudentModuleManagementSystem.BusinessLayer
{
    public interface IOptionSelector
    {
        string SelectStringOption();

        Student SelectWayOfChoosingStudent();
    }
}
