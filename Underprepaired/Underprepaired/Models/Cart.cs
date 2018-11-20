using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Underprepaired.Models
{
    public class Cart
    {
        // Primary Key
        public int ID { get; set; }
        
        public int UserID { get; set; }

        // Nav Property
        public ICollection<CartItem> CartItem { get; set; }
    }
}
