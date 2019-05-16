using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Persistance.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRespositories
    {
        public CategoryRepository(AppDbContext context):base(context)
        {

        }
        /*
         * We use the Categories database set ti access the categories table and then call the extension
         * method TOListAsync which is responsible for transforming the result of a query into a collection
         * of categories
         * 
         * 
         * The EF Core translates our method call to a SQL Query, the most efficient way possible
         * The Query is only executed when you call a method that will transform your data into a collection, or
         * when you use a method to take specific data
         */
        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _context.Categories.ToListAsync();
        }
        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
        }
        public async Task<Category> FindByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }
        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }
        public void Remove(Category category)
        {
            _context.Categories.Remove(category);
        }
    }
}
