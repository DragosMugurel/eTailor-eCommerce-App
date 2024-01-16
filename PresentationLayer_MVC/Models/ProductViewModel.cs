using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PresentationLayer_MVC.Models
{
    public class ProductViewModel
    {
        public ProductViewModel() { }
        public ProductViewModel(SelectList categories)
        {
            Categories = categories;
        }
        [Key]
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image_URL { get; set; }
        public int Category_Id { get; set; }
        public string Category_Name { get; set; }
        public SelectList Categories { get; set;}
    }
}
