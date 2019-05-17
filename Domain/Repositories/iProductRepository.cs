using Supermarket.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Repositories
{
    public interface iProductRepository
    {
        Task<IEnumerable<Product>> ListAsync();
    }
}
