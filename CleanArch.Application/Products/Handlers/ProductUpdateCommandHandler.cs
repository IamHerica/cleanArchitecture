using CleanArch.Application.Products.Commands;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Products.Handlers
{
    class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
    {
        private IProductRepository _productRepository;

        public ProductUpdateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if (product == null)
                throw new ApplicationException("Entity could not be found");
            product.Update(request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryId);
            return await _productRepository.UpdateAsync(product);
        }
    }
}
