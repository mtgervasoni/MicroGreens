using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroGreens.ProductApi.Models.DTOs;

namespace MicroGreens.ProductApi.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetProductById(int productId);
        Task<ProductDto> CreateUpdateProduct(ProductDto productDto);
        Task<bool> DeleteProduct(int productId);
    }
}
