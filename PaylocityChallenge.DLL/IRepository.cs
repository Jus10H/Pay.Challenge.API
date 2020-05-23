using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PaylocityChallenge.DLL
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        TEntity GetById(params object[] id);
        TEntity Add(TEntity entity);
        void Update(TEntity entity);


    }
}
