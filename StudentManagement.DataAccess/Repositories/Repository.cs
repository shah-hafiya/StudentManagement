using System;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using StudentManagement.Api.Entities;
using System.Data.Entity.Infrastructure;
using StudentManagement.DataAccess.Repositories.Extensions;
using StudentManagement.DataAccess.Repositories.Interfaces;

namespace StudentManagement.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : class, IEntity, new()
    {
        private readonly DbContext _entitiesContext;

        public Repository(DbContext entitiesContext)
        {
            if (entitiesContext == null)
                throw new ArgumentNullException("entitiesContext");

            _entitiesContext = entitiesContext;
        }

        public virtual IQueryable<T> GetAll()
            => _entitiesContext.Set<T>();

        public virtual IQueryable<T> AllIncluding(
            params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _entitiesContext.Set<T>();
            foreach (var includeProperty in includeProperties)
            {

                query = query.Include(includeProperty);
            }

            return query;
        }

        public T GetSingle(int key)
            => GetAll().FirstOrDefault(x => x.Id == key);

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
            => _entitiesContext.Set<T>().Where(predicate);

        public virtual PaginatedList<T> Paginate(
                    int pageIndex, int pageSize,
                    Expression<Func<T, int>> keySelector)
        {

            return Paginate(pageIndex, pageSize, keySelector, null);
        }

        public virtual PaginatedList<T> Paginate(
            int pageIndex, int pageSize,
            Expression<Func<T, int>> keySelector,
            Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includeProperties)
        {

            IQueryable<T> query =
                AllIncluding(includeProperties).OrderBy(keySelector);

            query = (predicate == null)
                ? query
                : query.Where(predicate);

            return query.ToPaginatedList(pageIndex, pageSize);
        }

        public virtual void Add(T entity)
        {

            DbEntityEntry dbEntityEntry = _entitiesContext.Entry<T>(entity);
            _entitiesContext.Set<T>().Add(entity);

            Save();
        }

        public virtual void Edit(T entity)
        {

            DbEntityEntry dbEntityEntry = _entitiesContext.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;

            Save();
        }

        public virtual void Delete(T entity)
        {

            DbEntityEntry dbEntityEntry = _entitiesContext.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;

            Save();
        }

        public virtual void Save()
            => _entitiesContext.SaveChanges();
    }
}
