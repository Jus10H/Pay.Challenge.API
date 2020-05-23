using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PaylocityChallenge.DLL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly PaylocityDbContext _context;
        private DbSet<TEntity> _entity;

        /// <summary>
        /// Constructor
        /// </summary>
        public Repository(PaylocityDbContext context)
        {
            _context = context;
            _entity = _context.Set<TEntity>();
        }

        /// <summary>
        /// Query over all entities of type TEntity
        /// </summary>
        public IQueryable<TEntity> GetAll()
        {
            return _entity.AsNoTracking();
        }

        /// <summary>
        /// Query over all entities of type TEntity
        /// </summary>
        public TEntity GetById(params object[] id)
        {
            return _entity.Find(id);
        }

        /// <summary>
        /// Adds an entity to the set.
        /// </summary>
        public TEntity Add(TEntity entity)
        {
            _entity.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        /// <summary>
        /// Updates an entity in the set.
        /// </summary>
        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

    }
}
