using AutoMapper;
using CleanMVC.Application.DTOs;
using CleanMVC.Application.Products.Commands;

namespace CleanMVC.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();
        }
    }
}
