namespace SportsStore.Entities;

public class Order
{
    public long OrderId { get; set; }

    public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();

    public string Name { get; } = string.Empty;

    public string Line1 { get; set; } = string.Empty;

    public string? Line2 { get; set; }

    public string? Line3 { get; set; }

    public string City { get; set; } = string.Empty;

    public string State { get; set; } = string.Empty;

    public string Zip { get; set; } = string.Empty;

    public string Country { get; set; } = string.Empty;

    public bool GiftWrap { get; set; }

    private Order()
    {
    }

    public Order(ICollection<CartLine> lines,
        string name,
        string line1,
        string? line2,
        string? line3,
        string city,
        string state,
        string zip,
        string country,
        bool giftWrap)
    {
        Lines = lines;
        Name = name;
        Line1 = line1;
        Line2 = line2;
        Line3 = line3;
        City = city;
        State = state;
        Zip = zip;
        Country = country;
        GiftWrap = giftWrap;
    }
}