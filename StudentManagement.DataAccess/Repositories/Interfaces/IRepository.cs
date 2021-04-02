using System;
using System.Linq;
using System.Linq.Expressions;
using StudentManagement.Api.Entities;

namespace StudentManagement.DataAccess.Repositories.Interfaces
{
    public interface IRepository<T>
        where T : class, IEntity, new()
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);

        T GetSingle(int id);

        PaginatedList<T> Paginate(
            int pageIndex, int pageSize,
            Expression<Func<T, int>> keySelector);

        PaginatedList<T> Paginate(
            int pageIndex, int pageSize,
            Expression<Func<T, int>> keySelector,
            Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includeProperties);

        void Add(T entity);
        void Edit(T entity);
        void Delete(T entity);
        void Save();
    }
}
