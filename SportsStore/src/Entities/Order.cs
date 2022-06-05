namespace SportsStore.Entities;

public class Order
{
    public long OrderID { get; set; }

    public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();

    public string Name { get; set; } = string.Empty;

    public string Line1 { get; set; } = string.Empty;

    public string Line2 { get; set; } = string.Empty;

    public string Line3 { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string State { get; set; } = string.Empty;

    public string Zip { get; set; } = string.Empty;

    public string Country { get; set; } = string.Empty;

    public bool GiftWrap { get; set; }
}