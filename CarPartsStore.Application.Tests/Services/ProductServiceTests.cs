using CarPartsStore.Application.DTOs;
using CarPartsStore.Application.Services;
using CarPartsStore.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Assert = Xunit.Assert;

namespace CarPartsStore.Application.Tests.Services
{
    public class ProductServiceTests
    {
        private ProductService productService;
        public ProductServiceTests()
        {
            productService = new ProductService(new Mock<IProductRepository>().Object);
        }
        [Fact]
        public void Post_ProdutoComPrecoNegativo_DeveLancarExcecao()
        {
            var produtoInvalido = new DTOs.ProductDTO
            {
                Id = 1,
                Name = "Name",
                Description = "Valid Description",
                Price = -10.0m,  // Preço negativo
                Stock = 10,
                Image = "image.png"
            };

            Action action = () => productService.AddAsync(produtoInvalido).Wait();

            var exception = Assert.Throws<AggregateException>(() => action());

            var innerException = exception.InnerException as ArgumentException;
            Assert.NotNull(innerException);
            Assert.Contains("Price must be greater than zero", innerException.Message);
        }

        [Fact]
        public void Post_ProdutoComNomeVazio_DeveLancarExcecao()
        {
            var produtoInvalido = new DTOs.ProductDTO
            {
                Id = 1,
                Name = "",  // Nome vazio
                Description = "Valid Description",
                Price = 10.0m,
                Stock = 10,
                Image = "image.png"
            };

            Action action = () => productService.AddAsync(produtoInvalido).Wait();

            var exception = Assert.Throws<AggregateException>(() => action());

            var innerException = exception.InnerException as ArgumentException;
            Assert.NotNull(innerException);
            Assert.Contains("Product name cannot be empty", innerException.Message);
        }
        [Fact]
        public void Post_ProdutoComDescricaoVazia_DeveLancarExcecao()
        {
            var produtoInvalido = new DTOs.ProductDTO
            {
                Id = 1,
                Name = "Name",
                Description = "",  // Descrição vazia
                Price = 10.0m,
                Stock = 10,
                Image = "image.png"
            };

            Action action = () => productService.AddAsync(produtoInvalido).Wait();

            var exception = Assert.Throws<AggregateException>(() => action());

            var innerException = exception.InnerException as ArgumentException;
            Assert.NotNull(innerException);
            Assert.Contains("Product description cannot be empty", innerException.Message);
        }
        [Fact]
        public void Post_ProdutoComEstoqueNegativo_DeveLancarExcecao()
        {
            var produtoInvalido = new DTOs.ProductDTO
            {
                Id = 1,
                Name = "Name",
                Description = "Valid Description",
                Price = 10.0m,
                Stock = -1,  // Estoque negativo
                Image = "image.png"
            };

            Action action = () => productService.AddAsync(produtoInvalido).Wait();

            var exception = Assert.Throws<AggregateException>(() => action());

            var innerException = exception.InnerException as ArgumentException;
            Assert.NotNull(innerException);
            Assert.Contains("Stock cannot be negative", innerException.Message);
        }
        



    }
}
