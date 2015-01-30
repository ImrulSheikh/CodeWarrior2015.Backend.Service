using System.Collections.Generic;
using System.Linq;
using System.Web;
using CW.Backend.DAL.CRUD.Entities;

namespace EShopper.Models {
    public class CategoryViewModel {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<CategoryViewModel> SubCategories { get; set; }

    }

    public class CategoryPropertyViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMandatory { get; set; }
        public List<string> AvailableValues { get; set; }

        public CategoryPropertyViewModel()
        {
            AvailableValues =  new List<string>();
        }
    }

}