using CleanMVC.Application.Products.Commands;
using CleanMVC.Domain.Entities;
using CleanMVC.Domain.Interfaces;
using MediatR;

namespace CleanMVC.Application.Products.Handlers
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public ProductUpdateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                throw new ApplicationException($"Error could not be found");
            }

            product.Update(request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryId);
            
            return await _productRepository.UpdateAsync(product);
        }
    }
}
