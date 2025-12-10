namespace ECommerce_Standard_.EcommerceApp.Core.Models
{
    public class Order
    {
        int orderId { get; set; }
        int userId { get; set; }
        int productId { get; set; }
        DateTime orderDate { get; set; }
        decimal totalAmount { get; set; }
    }
}
