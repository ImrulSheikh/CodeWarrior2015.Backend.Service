using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuySell.EntityModels
{
    public class ProductTag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TagType TagType  { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }

    public enum TagType
	{
        None = 0,
        UserProvided = 1,
        SystemProvided = 2
	}
}
