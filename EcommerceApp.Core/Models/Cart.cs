namespace ECommerce_Standard_.EcommerceApp.Core.Models
{
    public class Cart
    {
        public int userId { get; set; }
        public List<int>itemsIds { get; set; }
        public int id { get; set; }

    }
}
