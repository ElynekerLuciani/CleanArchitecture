using CleanMVC.Application.Products.Queries;
using CleanMVC.Domain.Entities;
using CleanMVC.Domain.Interfaces;
using MediatR;

namespace CleanMVC.Application.Products.Handlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _repository;

        public GetProductsQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetProductAsync();
        }
    }
}
