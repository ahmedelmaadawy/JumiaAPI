using JumiaEcommerceAPI.BusinessLogic.DTOs;

namespace JumiaEcommerceAPI.BusinessLogic.Interfaces
{
    public interface IProductService
    {
        void AddProduct(ProductToAddDTO product);
        List<ProductToReadDTO> GetAllProducts();
    }
}
