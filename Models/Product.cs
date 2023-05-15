using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductInfo.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        //public string PCategory { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

        //Category
        [Display(Name = "Category ID")]
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        
        public Category Category { get; set; }

        //Customer
        //public int CustomerID { get; set; }
        //[ForeignKey("CustomerID")]
        //public Customer Customer { get; set; }

    }
}
