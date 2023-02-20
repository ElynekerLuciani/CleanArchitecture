using CleanMVC.Domain.Entities;

namespace CleanMVC.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductAsync();
        Task<Product> GetByIdAsync(int id);
        
        //Adaptando para o estudo de CQRS
        //Task<Product> GetProductCategoryAsync(int id);
        Task<Product> CreateAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<Product> RemoveAsync(Product product);
    }
}
