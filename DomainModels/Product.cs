using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace DomainModels
{
    [Serializable]
    public class Product
    {
        [Key]
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image_URL { get; set; }
        public int Category_Id { get; set; }
        public string Category_Name { get; set; }
        public virtual List<Category> Category { get; set; }
        public Product()
        {
            this.Category = new List<Category>();
        }
    }
}
