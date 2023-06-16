using Challenge.DataAccessLayer.Interfaces;
using Challenge.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Challenge.ApplicationService.Test.Unit
{
    [TestClass]
    public class OrderServiceTests
    {
        [TestMethod]
        public async Task CreateOrder_ValidOrder_NoExceptionThrown()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var orderRepositoryMock = new Mock<IOrderRepository>();
            unitOfWorkMock.SetupGet(uow => uow.OrderRepository).Returns(orderRepositoryMock.Object);
            var orderService = new OrderService(unitOfWorkMock.Object);

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
            orderRepositoryMock.Verify(repo => repo.CreateOrder(order), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public async Task CreateOrder_InvalidOrder_ThrowsException()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var orderRepositoryMock = new Mock<IOrderRepository>();
            unitOfWorkMock.SetupGet(uow => uow.OrderRepository).Returns(orderRepositoryMock.Object);
            var orderService = new OrderService(unitOfWorkMock.Object);

            var order = new Order
            {
                CustomerID = 1,
                Quantity = 2
            };

            // Act & Assert
            await orderService.CreateOrderAsync(order);
        }
    }
}
