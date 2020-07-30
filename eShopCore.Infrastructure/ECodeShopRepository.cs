using eCodeShop.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eShopCore.Infrastructure
{
    public class ECodeShopRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbContext _context;
        private DbSet<TEntity> _entitySet;

        public IQueryable<TEntity> Table => EntitySet;
        public IQueryable<TEntity> TableNoTracking => EntitySet.AsNoTracking();

        #region Ctor

        public ECodeShopRepository(DbContext context)
        {
            _context = context;
            _entitySet = _context.Set<TEntity>();
        }

        #endregion

        public void Delete(TEntity entity)
        {
            _entitySet.Remove(entity);
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            _entitySet.RemoveRange(entities);
        }

        public TEntity GetById(object id)
        {
            return _entitySet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            _entitySet.Add(entity);
            _context.SaveChanges();
        }

        public void Insert(IEnumerable<TEntity> entities)
        {
            _entitySet.AddRange(entities);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _entitySet.Update(entity);
            _context.SaveChanges();
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            _entitySet.UpdateRange(entities);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets an entity set
        /// </summary>
        protected virtual DbSet<TEntity> EntitySet
        {
            get
            {
                if (_entitySet == null)
                    _entitySet = _context.Set<TEntity>();

                return _entitySet;
            }
        }
    }
}
