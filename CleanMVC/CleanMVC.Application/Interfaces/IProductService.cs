using CleanMVC.Application.DTOs;

namespace CleanMVC.Application.Interfaces
{
    public interface IProductService
    {
        Task<ProductDTO> GetById(int id);
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetProductCategory(int id);
        Task Add(ProductDTO productDTO);
        Task Update(ProductDTO productDTO);
        Task Delete(int id);
    }
}
