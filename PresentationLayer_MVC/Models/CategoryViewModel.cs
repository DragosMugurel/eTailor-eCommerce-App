using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PresentationLayer_MVC.Models
{
    public class CategoryViewModel
    {
        [Key]
        public int Category_Id { get; set; }

        public CategoryViewModel() { }

        public CategoryViewModel(SelectList products)
        {
            Products = products;
        }

        public SelectList Products { get; set; }
    }
}
