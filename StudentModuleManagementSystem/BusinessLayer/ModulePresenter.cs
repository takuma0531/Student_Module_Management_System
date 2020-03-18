using System;
using System.Collections.Generic;
using StudentModuleManagementSystem.DataAccessLayer;
using StudentModuleManagementSystem.Repository;

namespace StudentModuleManagementSystem.BusinessLayer
{
    public class ModulePresenter : IModulePresenter
    {
        private readonly IGenericRepository<Module> _moduleGenericRepository;

        public ModulePresenter(IGenericRepository<Module> moduleGenericRepository)
        {
            _moduleGenericRepository = moduleGenericRepository;
        }

        // read all module
        public List<Module> GetModules()
        {
            return _moduleGenericRepository.ReadAll();
        }

        // read a module
        public Module GetModuleById(int id)
        {
            return _moduleGenericRepository.ReadById(id);
        }

        // create new module
        public void RegisterModule(Module module)
        {
            _moduleGenericRepository.Create(module);
        }

        public void EditModule(Module module)
        {
            _moduleGenericRepository.Update(module);
        }

        // delete a module
        public void DeleteModule(int id)
        {
            _moduleGenericRepository.Delete(id);
        }

    }
}
