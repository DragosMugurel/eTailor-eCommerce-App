using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModels
{
    [Serializable]
    public class Category
    {
        [Key]
        public int Category_Id {  get; set; }
        public virtual List<Product> Products { get; set; }
        public Category()
        {
            this.Products = new List<Product>();
        }
    }
}
