using System.Collections.Generic;

namespace CW.Backend.DAL.Base.Repositories
{
    public interface IRepository<T> where T:class
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entityList);
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
