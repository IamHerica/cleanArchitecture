using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.DTOs
{
    //Para poder realizar o encaminhamento do Request para o Handler correto
    //Mapeamento DTO para os DTOs dos comandos e consultas que foram criadas
    public class DTOToDomainMappingProfile : Profile
    {
        CreateMap<ProductDTO, ProductCreateCommand>();
        CreateMap<ProductDTO, ProductUpdateCommand>();
        CreateMap<ProductDTO, ProductCreateQuery>();
    }
}
