namespace ECommerce_Standard_.EcommerceApp.Core.Models
{
    public class Product
    {
        int id { get; set; }
        string title { get; set; }
        string description { get; set; }
        decimal price { get; set; }
        decimal discountPercentage { get; set; }
        decimal rating { get; set; }
        int stock { get; set; } 
        string brand { get; set; }
        string category { get; set; }
        string thumbnail { get; set; }
        List<string> images { get; set; }
        List<string> tags { get; set; }
        int weigth { get; set; }
        decimal dimension_width { get; set; }
        decimal dimension_height { get; set; }
        decimal dimension_length { get; set; }


    }
}
