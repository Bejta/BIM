using BIMDomain.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BIMDomain.Models.DAL
{
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        private DbContext _context;
        private DbSet<TEntity> _set;

        public Repository(DbContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _set;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(
                new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return orderBy == null ? query.ToList() : orderBy(query).ToList();
        }

        public virtual TEntity GetByID(object id)
        {
            return _set.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            _set.Add(entity);
        }

        public virtual void InsertRange(IEnumerable<TEntity> entities)
        {
            _set.AddRange(entities);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            if (_context.Entry(entityToUpdate).State == EntityState.Detached)
            {
                _set.Attach(entityToUpdate);
            }
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = _set.Find(id);
            if (entityToDelete != null)
            {
                Delete(entityToDelete);
            }
        }

        public virtual void DeleteWhere(Expression<Func<TEntity, bool>> filter = null,
             Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
             string includeProperties = "")
        {
            IQueryable<TEntity> query = _set;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            foreach (var entity in query)
            {
                //_context.Entry(entity).State = EntityState.Deleted;
                _set.Remove(entity);
            }
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _set.Attach(entityToDelete);
            }
            _set.Remove(entityToDelete);
        }
    }
}