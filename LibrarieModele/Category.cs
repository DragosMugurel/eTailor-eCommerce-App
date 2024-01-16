using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace LibrarieModele
{
    public class Category
    {
        public int Category_Id { get; set; }

        public Category()
        { }

        public virtual Product Product { get; set; }

        public Category(int category_id = 0)
        {
            Category_Id = category_id;
        }

        public Category(DataRow linieDB)
        {
            Category_Id = Convert.ToInt32(linieDB["category_id"].ToString());
        }
    }
}
