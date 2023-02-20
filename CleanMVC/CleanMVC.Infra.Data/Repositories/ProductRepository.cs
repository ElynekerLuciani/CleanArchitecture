using CleanMVC.Domain.Entities;
using CleanMVC.Domain.Interfaces;
using CleanMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanMVC.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        readonly ApplicationDbContext _productContext;

        public ProductRepository(ApplicationDbContext context)
        {
            _productContext = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _productContext.Products.Add(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            //Adaptando para estudo de CQRS
            //return await _productContext.Products.FirstAsync(p => p.Id == id);

            return await _productContext.Products.Include(c => c.Category).SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductAsync()
        {
            return await _productContext.Products.ToListAsync();
        }

        //Adaptando para estudo de CQRS
        //public async Task<Product> GetProductCategoryAsync(int id)
        //{
        //    return await _productContext.Products.Include(c => c.Category).SingleOrDefaultAsync(p => p.Id == id);
        
        //}

        public async Task<Product> RemoveAsync(Product product)
        {
            _productContext.Remove(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _productContext.Update(product);
            await _productContext.SaveChangesAsync();
            return product;
        }
    }
}
