using Challenge.Domain;

namespace Challenge.ApplicationService
{
    public interface IOrderService
    {
        Task CreateOrderAsync(Order order);
        Task<Order> GetOrder(int orderId);
    }
}