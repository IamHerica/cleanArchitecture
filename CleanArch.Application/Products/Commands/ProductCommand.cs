using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Products.Commands
{
    //Usado pelas classes handlers
    //Vinculando os comandos com os Handlers
    //IRequest aceita o tipo que o respctivo Handler deverá retornar para o componente chamador
    //O Request contem propriedades que são usadas para fazer o input dos dados para os Handlers

    public abstract class ProductCommand : IRequest<Product>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
    }
}
