using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using StudentModuleManagementSystem.DataAccessLayer;

namespace StudentModuleManagementSystem.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly StudentModuleManagementDatabaseContext _context;
        protected readonly DbSet<T> _table;

        public GenericRepository(StudentModuleManagementDatabaseContext context)
        {
            this._context = context;
            this._table = _context.Set<T>();
        }

        public List<T> ReadAll()
        {
            return _table.ToList();
        }

        public T ReadById(int id)
        {
            return _table.Find(id);
        }

        public void Create(T entity)
        {
            _table.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _table.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            T studentToDelete = _table.Find(id);
            _table.Remove(studentToDelete);
            _context.SaveChanges();
        }
    }
}
