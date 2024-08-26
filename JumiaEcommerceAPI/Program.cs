
using JumiaEcommeceAPI.DataAccess.Context;
using JumiaEcommeceAPI.DataAccess.Entities;
using JumiaEcommeceAPI.DataAccess.Interfaces;
using JumiaEcommeceAPI.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace JumiaEcommerceAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //Context
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("Default"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            //AutoMapper
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddScoped<ApplicationDbContext>();

            // Repository
            //builder.Services.AddScoped<IGenericRepository<X>, GenericRepository<X>>();
            builder.Services.AddScoped<IGenericRepository<Category>, GenericRepository<Category>>();
            builder.Services.AddScoped<IGenericRepository<Order>, GenericRepository<Order>>();
            builder.Services.AddScoped<IGenericRepository<OrderItem>, GenericRepository<OrderItem>>();
            builder.Services.AddScoped<IGenericRepository<Payment>, GenericRepository<Payment>>();
            builder.Services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();
            builder.Services.AddScoped<IGenericRepository<ProductImage>, GenericRepository<ProductImage>>();
            builder.Services.AddScoped<IGenericRepository<Review>, GenericRepository<Review>>();
            builder.Services.AddScoped<IGenericRepository<Seller>, GenericRepository<Seller>>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
