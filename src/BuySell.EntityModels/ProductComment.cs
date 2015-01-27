using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuySell.EntityModels
{
    public class ProductComment
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int StarRating { get; set; }
        public int HelpfulHits { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
