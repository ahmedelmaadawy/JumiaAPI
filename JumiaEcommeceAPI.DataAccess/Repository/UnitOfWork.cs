using JumiaEcommeceAPI.DataAccess.Context;
using JumiaEcommeceAPI.DataAccess.Entities;
using JumiaEcommeceAPI.DataAccess.Interfaces;

namespace JumiaEcommeceAPI.DataAccess.Repository
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IGenericRepository<Review> Reviews { get; private set; }
        public IGenericRepository<Seller> Sellers { get; private set; }
        public IGenericRepository<ProductImage> ProductImages { get; private set; }
        public IGenericRepository<Product> Products { get; private set; }
        public IGenericRepository<Payment> Payments { get; private set; }
        public IGenericRepository<OrderItem> OrderItems { get; private set; }
        public IGenericRepository<Order> Orders { get; private set; }
        public IGenericRepository<Category> Categorys { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Reviews = new GenericRepository<Review>(_context);
            Sellers = new GenericRepository<Seller>(_context);
            ProductImages = new GenericRepository<ProductImage>(_context);
            Products = new GenericRepository<Product>(_context);
            Payments = new GenericRepository<Payment>(_context);
            OrderItems = new GenericRepository<OrderItem>(_context);
            Orders = new GenericRepository<Order>(_context);
            Categorys = new GenericRepository<Category>(_context);

        }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
