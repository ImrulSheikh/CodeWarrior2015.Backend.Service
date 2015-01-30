using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CW.Backend.DAL.CRUD.Entities
{
    public class CategoryProperty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMandatory { get; set; }
        public ICollection<CPAvailableValues> AvailableValues { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }

    public class CPAvailableValues
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public int CategoryPropertyId { get; set; }
        public virtual CategoryProperty CategoryProperty { get; set; }
    }
}