using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CW.Backend.DAL.Base.Entities;
using CW.Backend.DAL.CRUD.Entities;

namespace CW.Backend.DAL.Query.Entities
{
    public class UserFlatProfile
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public EntityStatus Status { get; set; }

    }
}
