using JumiaEcommeceAPI.DataAccess.Entities;
using JumiaEcommeceAPI.DataAccess.Interfaces;
using JumiaEcommerceAPI.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;

namespace JumiaEcommerceAPI.BusinessLogic.Services
{
    public class ProductImageService : IProductImageService
    {
        private readonly IUnitOfWork _context;
        public ProductImageService(IUnitOfWork context)
        {
            _context = context;
        }
        public void AddImageToProduct(int productId, IFormFile image)
        {
            Product product = _context.Products.getById(productId);
            if (product == null)
                throw new Exception("Wrong Id Product doenst exist");
            using (var ms = new MemoryStream())
            {
                image.CopyTo(ms);
                var imageData = ms.ToArray();
                var productImage = new ProductImage()
                {
                    ProductId = productId,
                    Image = imageData
                };

                _context.ProductImages.add(productImage);
                _context.Complete();
            }
        }

        public ProductImage GetImageById(int imageId)
        {
            var image = _context.ProductImages.getById(imageId);
            if (image == null)
                throw new Exception("Wrong Id Image doesnot exist in database");
            return image;
        }
    }
}
