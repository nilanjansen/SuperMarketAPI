using Supermarket.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Services.Communication
{
    public class SaveCategoryResponse:BaseResponse
    {
        public Category Category { get; private set; }
        public SaveCategoryResponse(bool success,string message,Category category):base(success,message)
        {
            Category = category;
        }
        /// <summary>
        /// Create a success response
        /// </summary>
        /// <param name="category">Saved Category</param>
        /// <returns>Response</returns>
        public SaveCategoryResponse(Category category):this(true,string.Empty,category)
        {

        }
        /// <summary>
        /// Creates an error message
        /// </summary>
        /// <param name="message">Error Message</param>
        /// <returns>Response.</returns>
        public SaveCategoryResponse(string message):this(false,message,null)
        {

        }
    }
}
