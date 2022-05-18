namespace SportsStore.Entities
{
    public class Product
    {
        public long ProductId { get; }

        public string Name { get; } = String.Empty;

        public string Description { get; } = String.Empty;

        public decimal Price { get; }

        public string Category { get; } = String.Empty;
    }
}
