namespace CleanMVC.Domain.Entities
{
    public sealed class Product : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string? Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string? Image { get; private set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
