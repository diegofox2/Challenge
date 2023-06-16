using Challenge.DataAccessLayer.Interfaces;
using Challenge.Domain;

namespace Challenge.ApplicationService
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateOrder(Order order)
        {
            await _unitOfWork.OrderRepository.CreateOrder(order);
        }

        public async Task<Order> GetOrder(int orderId)
        {
            return await _unitOfWork.OrderRepository.GetOrderByID(orderId);
        }
    }
}
