using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductInfo.Models
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Mail { get; set; }

        //Relationships
        //public List<Product> Products { get; set; }
    }
}
