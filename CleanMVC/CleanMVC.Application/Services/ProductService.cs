using AutoMapper;
using CleanMVC.Application.DTOs;
using CleanMVC.Application.Interfaces;
using CleanMVC.Domain.Entities;
using CleanMVC.Domain.Interfaces;

namespace CleanMVC.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productService, IMapper mapper)
        {
            _productRepository = productService ?? throw new ArgumentNullException(nameof(productService));
            _mapper = mapper;
        }

        public async Task Add(ProductDTO productDTO)
        {
            var productEntity = _mapper.Map<Product>(productDTO);
            await _productRepository.CreateAsync(productEntity);
        }

        public async Task Delete(int id)
        {
            var productEntity = _productRepository.GetByIdAsync(id).Result;
            await _productRepository.RemoveAsync(productEntity);
        }

        public async Task<ProductDTO> GetById(int id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<ProductDTO> GetProductCategory(int id)
        {
            var productEntity = await _productRepository.GetProductCategoryAsync(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productEntity = await _productRepository.GetProductAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(productEntity);
        }

        public async Task Update(ProductDTO productDTO)
        {
            var productEntity = _mapper.Map<Product>(productDTO);
            await _productRepository.UpdateAsync(productEntity);
        }
    }
}
