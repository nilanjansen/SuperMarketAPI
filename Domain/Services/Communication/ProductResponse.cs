using Supermarket.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Services.Communication
{
    public class ProductResponse:BaseResponse
    {
        public Product Product{ get; private set; }
        public ProductResponse(bool success, string message, Product product) : base(success, message)
        {
            Product = product;
        }
        /// <summary>
        /// Create a success response
        /// </summary>
        /// <param name="category">Saved Category</param>
        /// <returns>Response</returns>
        public ProductResponse(Product product) : this(true, string.Empty, product)
        {

        }
        /// <summary>
        /// Creates an error message
        /// </summary>
        /// <param name="message">Error Message</param>
        /// <returns>Response.</returns>
        public ProductResponse(string message) : this(false, message, null)
        {

        }
    }
}
