using StudentManagement.Api.Entities;
using StudentManagement.DataAccess.Context;
using StudentManagement.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace StudentManagement.DataAccess.Repositories
{
    internal class Repository<T> : IRepository<T>
        where T : class, IEntity
    {
        private readonly StudentManagementDbContext context;
        private readonly DbSet<T> set;

        public Repository(StudentManagementDbContext context)
        {
            this.context = context;
            set = this.context.Set<T>();
        }

        public T Add(T entity)
        {
            set.Add(entity);
            SaveChanges();

            return entity;
        }

        public void Delete(int id)
        {
            var find = set.Find(id);
            set.Remove(find);
            SaveChanges();
        }

        public IQueryable<T> Get()
        {
            return set;
        }

        

        public T GetById(int id)
        {
            var find = set.Find(id);
            return find;
        }

        public T Update(T entity)
        {
            SaveChanges();
            
            return entity;
            
        }

        private void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
