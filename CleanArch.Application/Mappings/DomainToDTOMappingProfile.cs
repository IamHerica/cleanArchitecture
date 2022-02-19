using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Domain.Entities;

namespace CleanArch.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        //Mapeando os objetos com suas determinadas tabelas
        public DomainToDTOMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}