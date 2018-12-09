using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Underprepaired.Models
{
    public class Order
    {
        public int ID { get; set; }

        public string Username { get; set; }

        public DateTime Date { get; set; }

        public decimal Total { get; set; }
    }
}
