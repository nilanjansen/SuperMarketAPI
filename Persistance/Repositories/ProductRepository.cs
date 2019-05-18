using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Persistance.Repositories
{
    public class ProductRepository:BaseRepository,IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) { }

        public Task AddAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> FindIdByAsync(int id)
        {
            return await _context.Products.Include(p => p.Category)
                        .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _context.Products.Include(p => p.Category).ToListAsync();
        }

        public void Remove(Product product)
        {
            _context.Products.Remove(product);
        }

        public void UpdateAsync(Product product)
        {
            _context.Products.Update(product);
        }
    }
}
