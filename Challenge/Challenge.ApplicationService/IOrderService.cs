using Challenge.Domain;

namespace Challenge.ApplicationService
{
    public interface IOrderService
    {
        Task CreateOrder(Order order);
        Task<Order> GetOrder(int orderId);
    }
}