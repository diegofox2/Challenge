using Challenge.Domain;

namespace Challenge.ApplicationService
{
    public interface IProductService
    {
        Task<Product> GetProduct(int id);

        Task AddNewProductAsync(Product product);
    }
}