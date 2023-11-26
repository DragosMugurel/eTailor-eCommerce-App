using Repository_DBFirst;

using System.Collections.Generic;

namespace eTailorViewModel.Models
{
    public class eTailorViewModel
    {
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public List<Order> Orders { get; set; }
        public List<Order_history> OrdersHistory { get; set; }
        public List<Payment> Payments { get; set; }
        public List<Shipping> Shippings { get; set; }
        public List<User> Users { get; set; }
        public List<Recommendation> Recommendations { get; set; }
    }
}
