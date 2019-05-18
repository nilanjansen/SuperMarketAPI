using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Domain.Services;
using Supermarket.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRespositories _categoryRespositories;
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IProductRepository productRepository,ICategoryRespositories categoryRespositories,IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _categoryRespositories = categoryRespositories;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductResponse> DeleteAsync(int id)
        {
            var existingProduct = await _productRepository.FindIdByAsync(id);

            if (existingProduct == null)
                return new ProductResponse("Product not found");
            try
            {
                _productRepository.Remove(existingProduct);
                await _unitOfWork.CompleteAsync();

                return new ProductResponse(existingProduct);
            }
            catch (Exception ex)
            {
                return new ProductResponse($"An error occured when deleting the product: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _productRepository.ListAsync();
        }

        public async Task<ProductResponse> SaveProductAsync(Product product)
        {
            try
            {

                var existingCategory = await _categoryRespositories.FindByIdAsync(product.CategoryId);
                if (existingCategory == null)
                {
                    return new ProductResponse("Invalid Category");
                }
                await _productRepository.AddAsync(product);
                await _unitOfWork.CompleteAsync();


                return new ProductResponse(product);
            }
            catch (Exception ex)
            {

                return new ProductResponse($"An error occured when saving the product: {ex.Message}");
            }
        }

        public async Task<ProductResponse> UpdateAsync(int id, Product product)
        {
            var existingProduct = await _productRepository.FindIdByAsync(id);
            if (existingProduct == null)
                return new ProductResponse("Product not found");
            var existingCategory = _categoryRespositories.FindByIdAsync(product.CategoryId);
            if (existingCategory == null)
                return new ProductResponse("Category not found");
            existingProduct.Name = product.Name;
            existingProduct.UnitOfMeasurement = product.UnitOfMeasurement;
            existingProduct.QuantityInPackage = product.QuantityInPackage;
            existingProduct.CategoryId = product.CategoryId;
            try
            {
                _productRepository.UpdateAsync(product);
                await _unitOfWork.CompleteAsync();

                return new ProductResponse(existingProduct);
            }
            catch (Exception ex)
            {
                return new ProductResponse($"An Error occured while updating the product:{ex.Message}");
            }
        }
    }
}
