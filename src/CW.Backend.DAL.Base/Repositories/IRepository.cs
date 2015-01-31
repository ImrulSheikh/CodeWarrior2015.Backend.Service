using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CW.Backend.DAL.Base.Repositories
{
    public interface IRepository<T> where T:class
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entityList);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllIncluding<TProperty>(Expression<Func<T, TProperty>> propertyExpression);
        T GetById(int id);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
