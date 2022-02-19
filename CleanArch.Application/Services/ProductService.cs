using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Products.Commands;
using CleanArch.Application.Products.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class ProductService : IProductService
    {
        //Injetando a instancia do MediatR para receber o request e invocar o Handler associado a ele
        //private IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public ProductService(IMapper mapper, IMediator mediator)
        {
            //Operador coalisense: verdadeiro -> atribui / falso -> lanca a exception
            //_productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            //var productsEntity = await _productRepository.GetProductsAsync();
            //return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);

            var productsQuery = new GetProductsQuery();

            if(productsQuery == null)
                throw new Exception($"Entity could not be loaded");

            var result = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(result);

        }

        public async Task<ProductDTO> GetById(int? id)
        {
            //var productsEntity = await _productRepository.GetByIdAsync(id);
            //return _mapper.Map<ProductDTO>(productsEntity);

            var productByIdQuery = new GetProductByIdQuery(id.Value);
            if (productByIdQuery == null)
                throw new Exception($"Entity could not be loaded");

            var result = await _mediator.Send(productByIdQuery);

            return _mapper.Map<ProductDTO>(result);

        }

        //public async Task<ProductDTO> GetProductCategory(int? id)
        //{
        //    //var productsEntity = await _productRepository.GetProductCategoryAsync(id);
        //    //return _mapper.Map<ProductDTO>(productsEntity);

        //    var productByIdQuery = new GetProductByIdQuery(id.Value);
        //    if (productByIdQuery == null)
        //        throw new Exception($"Entity could not be loaded");

        //    var result = await _mediator.Send(productByIdQuery);

        //    return _mapper.Map<ProductDTO>(result);

        //}

        public async Task Add(ProductDTO productDTO)
        {
            //var productEntity = _mapper.Map<Product>(productDTO);
            //await _productRepository.CreateAsync(productEntity);

            //definir mapeamento
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDTO);
            await _mediator.Send(productCreateCommand);
        }

        public async Task Update(ProductDTO productDTO)
        {
            //var categoryEntity = _mapper.Map<Product>(productDTO);
            //await _productRepository.UpdateAsync(categoryEntity);

            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDTO);
            await _mediator.Send(productUpdateCommand);
        }

        public async Task Remove(int? id)
        {
            //Sem o .Result, vai devolver uma task. Com ele, volta a Categoria
            //var categoryEntity = _productRepository.GetByIdAsync(id).Result;
            //await _productRepository.RemoveAsync(categoryEntity);

            var productRemoveCommand = new ProductRemoveCommand(id.Value);
            if(productRemoveCommand == null)
                throw new Exception($"Entity could not be loaded");

            await _mediator.Send(productRemoveCommand);


        }
    }
}
