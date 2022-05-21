namespace SportsStore.Entities
{
    public class Product
    {
        public long ProductId { get; }

        public string Name { get; } = string.Empty;

        public string Description { get; } = string.Empty;

        public decimal Price { get; }

        public string Category { get; } = string.Empty;
    }
}
