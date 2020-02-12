using CoffeeMug.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeMug.Repositories
{
    public interface IProductRepository
    {
        List<Product> FindAll();
        EntityEntry Save(Product product);
        Product FindById(Guid Id);
        void Remove(Product product);
        void Update(Product product);
    }
}
