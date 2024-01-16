namespace PresentationLayer_API.Models
{
    public class Product
    {
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image_URL { get; set; }
        public int Category_Id { get; set; }
        public string Category_Name { get; set; }
    }
}