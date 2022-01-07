namespace WebAPISamples.Models
{
    public class Customer
    {
        public string CustomerName { get; set; } = string.Empty;
        public List<Order> Orders { get; set; } = new List<Order>();
    }


    public class Order
    {
        public string OrderName { get; set; } = default!;

        public string OrderType { get; set; } = string.Empty;
    }
}
