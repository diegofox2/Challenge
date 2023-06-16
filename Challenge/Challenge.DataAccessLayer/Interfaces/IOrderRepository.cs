using Challenge.Domain;

namespace Challenge.DataAccessLayer.Interfaces
{
    public interface IOrderRepository
    {
        Task CreateOrder(Order order);
        Task<Order> GetOrderByID(int id);
    }
}