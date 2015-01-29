using System;

namespace CW.Backend.DAL.CRUD.Entities
{
    public class BaseCoreEntity
    {
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public EntityStatus Status { get; set; }
    }

    public enum EntityStatus
    {
        None = 0,
        Active = 1,
        Inactive = 2
    }
}
