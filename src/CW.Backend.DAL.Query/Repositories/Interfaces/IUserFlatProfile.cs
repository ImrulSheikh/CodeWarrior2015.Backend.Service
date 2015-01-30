using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CW.Backend.DAL.Base.Repositories;
using CW.Backend.DAL.Query.Entities;

namespace CW.Backend.DAL.Query.Repositories.Interfaces
{
    public interface IUserFlatRepository:IRepository<UserFlatProfile>
    {
    }
}
