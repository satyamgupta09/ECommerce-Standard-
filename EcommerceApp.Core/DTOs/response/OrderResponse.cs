namespace ECommerce_Standard_.EcommerceApp.Core.DTOs.response
{
    public class OrderResponse
    {
        public int productId { get; set; }
        public DateTime orderDate { get; set; }
        public decimal totalAmount { get; set; }

        // Product details
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public string thumbnail { get; set; }
    }
}
