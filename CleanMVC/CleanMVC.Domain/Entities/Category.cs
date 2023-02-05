using CleanMVC.Domain.Validation;

namespace CleanMVC.Domain.Entities
{
    public sealed class Category : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public ICollection<Product> Products { get; private set; } = null!;

        public Category() { }

        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name) : base(id)
        {
            DomainExceptionValidation.When(id < 1, "Invalid Id value");

            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name: name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name: minimun 3 characters");

            Name = name;
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

    }
}
