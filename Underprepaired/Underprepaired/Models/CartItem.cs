using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Underprepaired.Models
{
    public class CartItem
    {
        // Composite Key - ProductID/CartID
        public int ProductID { get; set; }
        public int CartID { get; set; }

        public int Quantity { get; set; }

        // Nav Properties
        public Product Product { get; set; }
        public Cart Cart { get; set; }
    }
}
