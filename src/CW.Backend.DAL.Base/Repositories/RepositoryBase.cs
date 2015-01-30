using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace CW.Backend.DAL.Base.Repositories
{
    public class RepositoryBase<T> : IRepository<T>, IDisposable where T : class
    {
        private readonly DbContext _ctx;
        public RepositoryBase(DbContext context)
        {
            _ctx = context;
        }

        public void Add(T entity)
        {
            _ctx.Set<T>().Add(entity);
            //_ctx.Set<T>().Attach(entity);
            //_ctx.Entry(entity).State = EntityState.Added;
        }

        public void AddRange(IEnumerable<T> entityList)
        {
            _ctx.Set<T>().AddRange(entityList);
        }

        public IEnumerable<T> GetAll()
        {
            return _ctx.Set<T>();
        }

        public T GetById(int id)
        {
            return _ctx.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _ctx.Entry(entity).State = EntityState.Deleted;
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}