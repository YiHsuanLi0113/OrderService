namespace OrderService.Models;
public class CheckoutCommand
{
    public Guid? SessionId { get; set; }
    public CustomerDetails Customer { get; set; }
    public Address BillingAddress { get; set; }
    public Address DeliveryAddress { get; set; }
    public bool DeliverToBillingAddress { get; set; }
    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
    }
    public class CustomerDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
