using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace LibrarieModele
{
    public class Category
    {
        [Key]
        public int Category_Id { get; set; }
        public string Category_Name { get; set; }

        public Category()
        { }

        public Category(string category_name, int category_id = 0)
        {
            Category_Id = category_id;
            Category_Name = category_name;
        }

        public Category(DataRow linieDB)
        {
            Category_Id = Convert.ToInt32(linieDB["category_id"].ToString());
            Category_Name = linieDB["category_name"].ToString();
        }
    }
}
