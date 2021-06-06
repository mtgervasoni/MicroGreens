using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroGreens.ProductApi.DbContexts;
using MicroGreens.ProductApi.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace MicroGreens.ProductApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            var product = Mapper.productdto_product(productDto);
            if(product.ProductId > 0)
            {
                _db.Products.Update(product);
            }
            else
            {
                await _db.Products.AddAsync(product);
            }
            await _db.SaveChangesAsync();
            return Mapper.product_productDto(product);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                var prod = await _db.Products.FirstOrDefaultAsync(t => t.ProductId == productId);
                if(prod == null)
                {
                    return false;
                }
                _db.Products.Remove(prod);
                await _db.SaveChangesAsync();
                return true;

            }catch(Exception)
            {
                return false;
            }
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            var prod = await _db.Products.FirstOrDefaultAsync(t => t.ProductId == productId);
            var dto = Mapper.product_productDto(prod);
            return dto;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
           return  _db.Products.Select(Mapper.product_productDto).ToList();
        }
    }
}
