using System;
using System.Collections.Generic;

namespace StudentModuleManagementSystem.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> ReadAll();

        T ReadById(int id);

        void Create(T entity);

        void Update(T obj);

        void Delete(int id);
    }
}
