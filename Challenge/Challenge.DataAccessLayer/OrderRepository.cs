using Challenge.DataAccessLayer.Interfaces;
using Challenge.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Challenge.DataAccessLayer
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderManagementContext _dbContext;

        public OrderRepository(OrderManagementContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Order> GetOrderByID(int id)
        {
            return await _dbContext.Orders.FirstOrDefaultAsync(o => o.ID == id);
        }

        public async Task CreateOrder(Order order)
        {
            await _dbContext.Database.ExecuteSqlRawAsync("EXEC CalculateTotalCostAndCreateOrder @CustomerID, @ProductID, @Quantity",
                new SqlParameter("@CustomerID", order.CustomerID),
                new SqlParameter("@ProductID", order.Product.ID),
                new SqlParameter("@Quantity", order.Quantity));
        }
    }
}
