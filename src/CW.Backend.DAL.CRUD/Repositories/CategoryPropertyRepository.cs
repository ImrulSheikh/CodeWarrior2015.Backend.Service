using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CW.Backend.DAL.Base.Repositories;
using CW.Backend.DAL.CRUD.Contexts;
using CW.Backend.DAL.CRUD.Entities;

namespace CW.Backend.DAL.CRUD.Repositories {
    public class CategoryPropertyRepository : RepositoryBase<CategoryProperty> {
        public CategoryPropertyRepository(DbContext context)
            : base(context) {
        }
        public CategoryPropertyRepository()
            : base(new ProductCRUDContext()) {
        }
    }
}
