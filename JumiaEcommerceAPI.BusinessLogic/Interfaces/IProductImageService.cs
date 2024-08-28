
using JumiaEcommeceAPI.DataAccess.Entities;
using Microsoft.AspNetCore.Http;

namespace JumiaEcommerceAPI.BusinessLogic.Interfaces
{
    public interface IProductImageService
    {
        void AddImageToProduct(int productId, IFormFile image);
        ProductImage GetImageById(int imageId);
    }
}
