﻿using CleanMVC.Domain.Validation;

namespace CleanMVC.Domain.Entities
{
    public sealed class Product : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string? Image { get; private set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public Product(int id, string name, string description, decimal price, int stock, string image) : base(id)
        {
            DomainExceptionValidation.When(id < 1, "Invalid Id value");
            
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short minimum 3 characters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description. Description is required");
            DomainExceptionValidation.When(description.Length < 5, "Invalid description, too short minimum 5 characters");
            DomainExceptionValidation.When(price < 0, "Invalid price value");
            DomainExceptionValidation.When(stock < 0, "Invalid stock value");
            DomainExceptionValidation.When(Id < 1, "Invalid Id value");
            DomainExceptionValidation.When(image?.Length > 250, "Invalid image. Maximum 250 characters");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }
    }
}
