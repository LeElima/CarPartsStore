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
            ValidateProduct(productDto);
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
        private void ValidateProduct(ProductDTO product)
        {
            // Verificando se o nome está vazio
            if (string.IsNullOrWhiteSpace(product.Name))
            {
                throw new ArgumentException("Product name cannot be empty", nameof(product.Name));
            }

            // Verificando se a descrição está vazia
            if (string.IsNullOrWhiteSpace(product.Description))
            {
                throw new ArgumentException("Product description cannot be empty", nameof(product.Description));
            }

            // Verificando se o preço é menor ou igual a zero
            if (product.Price <= 0)
            {
                throw new ArgumentException("Price must be greater than zero", nameof(product.Price));
            }

            // Verificando se o estoque é negativo
            if (product.Stock < 0)
            {
                throw new ArgumentException("Stock cannot be negative", nameof(product.Stock));
            }

            // Verificando se a imagem está no formato esperado (opcional, mas bom para garantir)
            if (!string.IsNullOrWhiteSpace(product.Image) && !IsValidImageUrl(product.Image))
            {
                throw new ArgumentException("Product image URL is invalid", nameof(product.Image));
            }
        }

        private bool IsValidImageUrl(string imageUrl)
        {
            // Implementação de validação para URL de imagem (apenas um exemplo simples)
            Uri uriResult;
            return Uri.TryCreate(imageUrl, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
