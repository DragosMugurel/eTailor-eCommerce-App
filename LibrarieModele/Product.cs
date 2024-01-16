using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace LibrarieModele
{
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

        public virtual Category Category { get; set; }
        public Product()
        { }

        public Product(string product_name, string description, decimal price, string image_url, string category_name, int product_id = 0, int category_id = 0)
        {
            Product_Id = product_id;
            Product_Name = product_name;
            Description = description;
            Price = price;
            Image_URL = image_url;
            Category_Id = category_id;
            Category_Name = category_name;
        }

        public Product(DataRow linieDB)
        {
            Product_Id = Convert.ToInt32(linieDB["product_id"].ToString());
            Product_Name = linieDB["name"].ToString();
            Description = linieDB["description"].ToString();
            Price = Convert.ToDecimal(linieDB["price"].ToString());
            Image_URL = linieDB["image_url"].ToString();
            Category_Id = Convert.ToInt32(linieDB["category_id"].ToString());
            Category_Name = (linieDB["category_name"].ToString());
        }
    }
}
