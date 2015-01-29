using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarrior2015.Backend.Service.ProductCRUD.Repositories.Interfaces
{
    public interface IRepository<T> where T:class
    {
        void Add(T entity);
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
