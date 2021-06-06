﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroGreens.ProductApi.Models.DTOs
{
    public class Mapper
    {
        public static readonly Func<Product, ProductDto> product_productDto = x => x == null ? null : new ProductDto
        {
           CategoryName = x.CategoryName,
           Description = x.Description,
           ImageUrl = x.ImageUrl,
           Name = x.Name,
           Price = x.Price,
           ProductId = x.ProductId
        };

        public static readonly Func<ProductDto, Product> productdto_product = x => x == null ? null : new Product
        {
            CategoryName = x.CategoryName,
            Description = x.Description,
            ImageUrl = x.ImageUrl,
            Name = x.Name,
            Price = x.Price,
            ProductId = x.ProductId
        };
    }
}
