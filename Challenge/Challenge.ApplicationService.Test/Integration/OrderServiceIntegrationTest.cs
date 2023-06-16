using Challenge.DataAccessLayer;
using Challenge.DataAccessLayer.Interfaces;
using Challenge.Domain;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Challenge.ApplicationService.Test.Integration
{
    [TestClass]
    public class OrderServiceIntegrationTests
    {
        private OrderManagementContext _context;

        [TestInitialize]
        public async Task TestInitialize()
        {
            _context = new OrderManagementContext();
            
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM PRODUCTS");
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM ORDERS");
            await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('PRODUCTS', RESEED, 0)");
            await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('ORDERS', RESEED, 0)");

            await _context.Database.ExecuteSqlRawAsync("INSERT INTO PRODUCTS VALUES ('Cafe', 100)");
        }

        [TestCleanup]
        public async Task TestCleanUp()
        {
            _context = new OrderManagementContext();

            await _context.Database.ExecuteSqlRawAsync("DELETE FROM PRODUCTS");
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM ORDERS");
            await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('PRODUCTS', RESEED, 0)");
            await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('ORDERS', RESEED, 0)");
        }


        [TestMethod]
        public async Task CreateOrder_ValidOrder_NoExceptionThrown()
        {
            // Arrange
            var orderRepository = new OrderRepository(_context);
            
            var productRepositoryMock = new Mock<IProductRepository>();
            
            var unitOfWork = new UnitOfWork(_context, orderRepository, productRepositoryMock.Object);
            
            var orderService = new OrderService(unitOfWork);

            var order = new Order
            {
                CustomerID = 1,
                Product = new Product
                {
                    ID = 1,
                },
                Quantity = 2
            };

            // Act
            await orderService.CreateOrderAsync(order);

            // Assert
            Assert.IsNotNull(orderRepository.GetOrderByID(1));
        }

    }
}
