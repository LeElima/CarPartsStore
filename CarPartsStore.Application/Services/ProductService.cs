using CarPartsStore.Application.DTOs;
using CarPartsStore.Application.Services.Interfaces;
using CarPartsStore.Domain.Entities;
using CarPartsStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPartsStore.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(ProductDTO productDto)
        {
            var product = new Product()
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Deleted = false

            };
            await _repository.CreateAsync(product);

        }

        public async Task<ProductDTO> GetByIdAsync(int? id)
        {
            var product = await _repository.GetByIdAsync(id);
            if(product == null) return new ProductDTO();
            var productDTO = new ProductDTO()
            {
                Description = product.Description,
                Name = product.Name,
                Id = product.Id
            };
            return productDTO; 
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var products = await _repository.GetProductsAsync();
            var listDTOs = products.Select(x => new ProductDTO()
            {
                Name = x.Name,
                Description = x.Description,
                Id = x.Id
            });
            return listDTOs;
        }

        public async Task RemoveAsync(int? id)
        {
            var product = await _repository.GetByIdAsync(id);
            if(product == null) return;
            await _repository.RemoveAsync(product);
        }

        public async Task UpdateAsync(ProductDTO productDto)
        {
            var product = new Product()
            {
                Name= productDto.Name,
                Description= productDto.Description,
                Id = productDto.Id
            };
            await _repository.UpdateAsync(product);
        }
    }
}
