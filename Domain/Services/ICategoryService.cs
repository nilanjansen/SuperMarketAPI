﻿using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Services
{
    public interface ICategoryService
    { 
        // The ListAsync method must asynchrounously return the enumeration of categories.

        //The Task class, encapsulating the return indicates asynchrony, we need to think in an asynchronous method due to 
        //fact that we have to wait for the database to complete some operation to return the data, and this process can take 
        //a while. 
        Task<IEnumerable<Category>> ListAsync();
        Task<CategoryResponse> SaveAsync(Category category);
        Task<CategoryResponse> UpdateAsync(int id, Category category);
        Task<CategoryResponse> DeleteAsync(int id);
    }
}
