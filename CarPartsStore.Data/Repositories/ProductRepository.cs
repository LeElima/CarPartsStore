using CarPartsStore.Data.Context;
using CarPartsStore.Domain.Entities;
using CarPartsStore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPartsStore.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        CarPartsStoreContext _context;

        public ProductRepository(CarPartsStoreContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            return await _context.Products.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> GetProductCategoryAsync(int? id)
        {
            return await _context.Products.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> RemoveAsync(Product category)
        {
            _context.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Product> UpdateAsync(Product category)
        {
            _context.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
