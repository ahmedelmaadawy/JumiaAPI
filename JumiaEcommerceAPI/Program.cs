
using JumiaEcommeceAPI.DataAccess.Context;
using JumiaEcommeceAPI.DataAccess.Entities;
using JumiaEcommeceAPI.DataAccess.Interfaces;
using JumiaEcommeceAPI.DataAccess.Repository;
using JumiaEcommerceAPI.BusinessLogic.Interfaces;
using JumiaEcommerceAPI.BusinessLogic.Mapping;
using JumiaEcommerceAPI.BusinessLogic.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace JumiaEcommerceAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //Context
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("Default"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            //AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddScoped<ApplicationDbContext>();
            //CORS Policy
            builder.Services.AddCors(corsOptions =>
            {
                corsOptions.AddPolicy("MyPolicy", CorsPolicyBuilder =>
                {
                    CorsPolicyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
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

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Services
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IProductImageService, ProductImageService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();
            app.UseCors("MyPolicy");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
