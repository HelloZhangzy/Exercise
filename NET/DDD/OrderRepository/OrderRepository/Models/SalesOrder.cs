namespace OrderRepository.Models
{    
    public partial class SalesOrder:Order
    {
        public System.DateTime ShippingDate { get; set; }
        public System.DateTime CancelDate { get; set; }
        public string Status { get; set; }
    }
}
