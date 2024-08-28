using AutoMapper;
using JumiaEcommeceAPI.DataAccess.Entities;
using JumiaEcommeceAPI.DataAccess.Interfaces;
using JumiaEcommerceAPI.BusinessLogic.DTOs.Product;
using JumiaEcommerceAPI.BusinessLogic.Interfaces;

namespace JumiaEcommerceAPI.BusinessLogic.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void AddProduct(ProductToAddDTO product)
        {
            Product productToAdd = _mapper.Map<Product>(product);
            _context.Products.add(productToAdd);
            _context.Complete();
        }

        public List<ProductToReadDTO> GetAllProducts()
        {
            List<Product> products = _context.Products.getAll().ToList();
            var productsToReturn = _mapper.Map<List<ProductToReadDTO>>(products);
            return productsToReturn;
        }

        public ProductDetailsDTO GetById(int id)
        {
            Product product = _context.Products.getById(id);
            if (product is null)
                throw new Exception("Product does not exist in database wrong Id");
            var productToReturn = _mapper.Map<ProductDetailsDTO>(product);
            if (product.Images.Count() > 0)
            {
                foreach (var item in product.Images)
                {
                    productToReturn.ImagesUrl.Add(item.Id.ToString());
                }
            }
            return productToReturn;
        }
    }
}
