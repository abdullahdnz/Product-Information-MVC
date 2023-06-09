﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductInfo.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        //Relationships
        public List<Product> Products { get; set; }
    }
}
