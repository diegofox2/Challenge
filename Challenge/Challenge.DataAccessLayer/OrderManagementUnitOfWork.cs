using Challenge.DataAccessLayer.Interfaces;

namespace Challenge.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderManagementContext _dbContext;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public UnitOfWork(OrderManagementContext dbContext, IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _dbContext = dbContext;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public IOrderRepository OrderRepository { get { return _orderRepository; } }

        public IProductRepository ProductRepository { get { return _productRepository; } }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
