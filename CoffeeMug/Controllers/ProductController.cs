using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeMug.Dto;
using CoffeeMug.Models;
using CoffeeMug.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CoffeeMug.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IProductRepository _productRepository { get; set; }

        [HttpGet]
        public List<Product> Get()
        {
            return _productRepository.FindAll();
        }

        [HttpGet("{id}")]
        public Product Get(Guid Id)
        {
            Product product = _productRepository.FindById(Id);
            return product;
        }

        [HttpPost]
        public Guid? Post([FromBody] ProductCreateRequestDto request)
        {
            if(!ModelState.IsValid)
            {
                return null;
            }

            Product product = convertToProduct(request);

            EntityEntry entityEntry = _productRepository.Save(product);
            Product savedProduct = (Product) entityEntry.Entity;

            return savedProduct.Id;
        }

        [HttpPut]
        public void Put([FromBody] ProductUpdateRequestDto request)
        {
            if(!ModelState.IsValid)
            {
                return;
            }

            Product foundProduct = _productRepository.FindById(request.Id);

            if(foundProduct == null)
            {
                return;
            }

            foundProduct.Name = request.Name;
            foundProduct.Price = request.Price;

            _productRepository.Update(foundProduct);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid Id)
        {
            Product product = _productRepository.FindById(Id);
            _productRepository.Remove(product);
        }

        private Product convertToProduct(ProductCreateRequestDto request)
        {
            Product product = new Product();

            product.Name = request.Name;
            product.Price = request.Price;

            return product;
        }

    }
}