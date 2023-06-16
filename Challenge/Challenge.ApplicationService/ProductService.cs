using Challenge.DataAccessLayer.Interfaces;
using Challenge.Domain;

namespace Challenge.ApplicationService
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _unitOfWork.ProductRepository.GetProductByID(id);
        }
    }
}
