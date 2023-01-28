namespace CleanMVC.Domain.Entities
{
    public sealed class Category : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public ICollection<Product>? Products { get; private set; }

    }
}
