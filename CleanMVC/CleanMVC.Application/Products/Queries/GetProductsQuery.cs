using CleanMVC.Domain.Entities;
using MediatR;

namespace CleanMVC.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
