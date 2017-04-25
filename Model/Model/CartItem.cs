using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    [Serializable]
    public class CartItem
    {
        public Products Product { get; set; }

        public int Quantity { get; set; }

    }
}
