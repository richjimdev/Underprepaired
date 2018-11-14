using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Underprepaired.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "20 characters or less required")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string ImageURL { get; set; }
    }
}
