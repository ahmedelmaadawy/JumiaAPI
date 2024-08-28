using JumiaEcommerceAPI.BusinessLogic.DTOs.Product;

namespace JumiaEcommerceAPI.BusinessLogic.Interfaces
{
    public interface IProductService
    {
        void AddProduct(ProductToAddDTO product);
        List<ProductToReadDTO> GetAllProducts();
        ProductDetailsDTO GetById(int id);
    }
}
