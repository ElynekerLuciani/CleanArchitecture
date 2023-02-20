using AutoMapper;
using CleanMVC.Application.DTOs;
using CleanMVC.Application.Interfaces;
using CleanMVC.Application.Products.Commands;
using CleanMVC.Application.Products.Queries;
using CleanMVC.Domain.Entities;
using CleanMVC.Domain.Interfaces;
using MediatR;

namespace CleanMVC.Application.Services
{
    public class ProductService : IProductService
    {
        //private readonly IProductRepository _productRepository;
        //private readonly IMapper _mapper;

        //public ProductService(IProductRepository productService, IMapper mapper)
        //{
        //    _productRepository = productService ?? throw new ArgumentNullException(nameof(productService));
        //    _mapper = mapper;
        //}

        //public async Task Add(ProductDTO productDTO)
        //{
        //    var productEntity = _mapper.Map<Product>(productDTO);
        //    await _productRepository.CreateAsync(productEntity);
        //}

        //public async Task Delete(int id)
        //{
        //    var productEntity = _productRepository.GetByIdAsync(id).Result;
        //    await _productRepository.RemoveAsync(productEntity);
        //}

        //public async Task<ProductDTO> GetById(int id)
        //{
        //    var productEntity = await _productRepository.GetByIdAsync(id);
        //    return _mapper.Map<ProductDTO>(productEntity);
        //}

        //public async Task<ProductDTO> GetProductCategory(int id)
        //{
        //    var productEntity = await _productRepository.GetProductCategoryAsync(id);
        //    return _mapper.Map<ProductDTO>(productEntity);
        //}

        //public async Task<IEnumerable<ProductDTO>> GetProducts()
        //{
        //    var productEntity = await _productRepository.GetProductAsync();
        //    return _mapper.Map<IEnumerable<ProductDTO>>(productEntity);
        //}

        //public async Task Update(ProductDTO productDTO)
        //{
        //    var productEntity = _mapper.Map<Product>(productDTO);
        //    await _productRepository.UpdateAsync(productEntity);
        //}


        //Adaptando para estudo de CQRS

        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsQuery = new GetProductsQuery();

            if(productsQuery == null)
            {
                throw new Exception($"Entity could not be loaded");
            }

            var result = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task Add(ProductDTO productDTO)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDTO);
            await _mediator.Send(productCreateCommand);
        }

        public async Task Delete(int id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id);
            
            if(productRemoveCommand == null)
            {
                throw new Exception($"Entity could not be loaded");
            }

            await _mediator.Send(productRemoveCommand);
        }

        public async Task<ProductDTO> GetById(int id)
        {
            var productByIdQuery = new GetProductByIdQuery(id);
            
            if(productByIdQuery == null)
            {
                throw new Exception($"Entity could not be loaded");
            }

            var result = await _mediator.Send(productByIdQuery);

            return _mapper.Map<ProductDTO>(result);
        }

        //public async Task<ProductDTO> GetProductCategory(int id)
        //{
        //    var productByIdQuery = new GetProductByIdQuery(id);

        //    if (productByIdQuery == null)
        //    {
        //        throw new Exception($"Entity could not be loaded");
        //    }

        //    var result = await _mediator.Send(productByIdQuery);

        //    return _mapper.Map<ProductDTO>(result);
        //}

        public async Task Update(ProductDTO productDTO)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDTO);
            await _mediator.Send(productUpdateCommand);
        }
    }
}
