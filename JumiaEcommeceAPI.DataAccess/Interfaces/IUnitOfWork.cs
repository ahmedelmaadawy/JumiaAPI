using JumiaEcommeceAPI.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumiaEcommeceAPI.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Seller> Sellers {  get; }
        IGenericRepository<Review> Reviews { get; }
        IGenericRepository<ProductImage> ProductImages { get; }
        IGenericRepository<Product> Products { get; }
        IGenericRepository<Payment> Payments { get; }
        IGenericRepository<OrderItem> OrderItems { get; }
        IGenericRepository<Order> Orders { get; }
        IGenericRepository<Category> Categorys { get; }

        int Complete();

    }
}
