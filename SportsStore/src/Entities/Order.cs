namespace SportsStore.Entities;

public class Order
{
    public long OrderId { get; private set; }

    public ICollection<CartLine> Lines { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string Line1 { get; private set; } = string.Empty;

    public string? Line2 { get; private set; }

    public string? Line3 { get; private set; }

    public string City { get; private set; } = string.Empty;

    public string State { get; private set; } = string.Empty;

    public string Zip { get; private set; } = string.Empty;

    public string Country { get; private set; } = string.Empty;

    public bool GiftWrap { get; private set; }

    private Order()
    {
        Lines = new List<CartLine>();
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