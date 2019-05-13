using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRespositories _categoryRepository;
        public CategoryService(ICategoryRespositories categoryRespository)
        {
            this._categoryRepository = categoryRespository;
        }

        public Task<IEnumerable<Category>> ListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
