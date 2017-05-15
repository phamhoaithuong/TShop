using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public class CategoryViewModel
    {
        public IEnumerable<ProductViewModel> Product { get; set; }

        public IEnumerable<Categories> Category { get; set; }

    }
}
