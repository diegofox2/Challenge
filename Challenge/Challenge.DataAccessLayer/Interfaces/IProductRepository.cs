using Challenge.Domain;

namespace Challenge.DataAccessLayer.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByID(int id);
    }
}