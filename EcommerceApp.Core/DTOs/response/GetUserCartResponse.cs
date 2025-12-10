namespace ECommerce_Standard_.EcommerceApp.Core.DTOs.response
{
    public class GetUserCartResponse
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public decimal discountPercentage { get; set; }
        public decimal rating { get; set; }
        public int stock { get; set; }
        public string brand { get; set; }
        public string category { get; set; }
        public string thumbnail { get; set; }
        public List<string> images { get; set; }
        public List<string> tags { get; set; }
        public int weight { get; set; }
        public decimal dimension_width { get; set; }
        public decimal dimension_height { get; set; }
        public decimal dimension_length { get; set; }

        public int qty { get; set; }
    }
}
