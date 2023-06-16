using Challenge.DataAccessLayer.Interfaces;
using Challenge.Domain;
using Microsoft.EntityFrameworkCore;

namespace Challenge.DataAccessLayer
{
    public class ProductRepository : IProductRepository
    {
        private readonly OrderManagementContext _dbContext;

        public ProductRepository(OrderManagementContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> GetProductByID(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(p => p.ID == id);
        }

        public void AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
        }

    }
}
