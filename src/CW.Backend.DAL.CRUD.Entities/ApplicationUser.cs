using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CW.Backend.DAL.Base.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CW.Backend.DAL.CRUD.Entities
{
    public class ApplicationUser : IdentityUser
    {
        //[StringLength(50)]
        //public string FirstName { get; set; }
        [StringLength(50)]
        public string FullName { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Order> Orders { get; set; }

        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public EntityStatus Status { get; set; }
    }
}
