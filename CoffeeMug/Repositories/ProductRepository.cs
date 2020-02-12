using CoffeeMug.Context;
using CoffeeMug.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeMug.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public List<Product> FindAll()
        {
            return _context.Products.ToList();
        }

        public Product FindById(Guid Id)
        {
            return _context.Products.Where(p => p.Id == Id).SingleOrDefault();
        }

        public void Remove(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public EntityEntry Save(Product product)
        {
            EntityEntry savedProduct = _context.Products.Add(product);
            _context.SaveChanges();

            return savedProduct;
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }
}
