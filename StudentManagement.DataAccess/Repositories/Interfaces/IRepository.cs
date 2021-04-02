using StudentManagement.Api.Entities;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagement.DataAccess.Repositories.Interfaces
{
    public interface IRepository<T>
        where T: class, IEntity
    {
        IQueryable<T> Get();
        T Add(T entity);
        T Update(T entity);
        void Delete(int id);

        T GetById(int id);

    }
}
