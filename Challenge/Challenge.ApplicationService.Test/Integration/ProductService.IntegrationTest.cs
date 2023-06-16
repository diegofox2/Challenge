using Challenge.DataAccessLayer.Interfaces;
using Challenge.DataAccessLayer;
using Challenge.Domain;
using Moq;
using Microsoft.EntityFrameworkCore;

namespace Challenge.ApplicationService.Test.Integration
{
    [TestClass]
    public class ProductServiceIntegrationTest
    {
        private OrderManagementContext _context;

        [TestInitialize]
        public async Task TestInitialize()
        {
            _context = new OrderManagementContext();

            await _context.Database.ExecuteSqlRawAsync("DELETE FROM PRODUCTS");
            await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('PRODUCTS', RESEED, 0)");
        }

        [TestCleanup]
        public async Task TestCleanUp()
        {
            _context = new OrderManagementContext();

            await _context.Database.ExecuteSqlRawAsync("DELETE FROM PRODUCTS");
            await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('PRODUCTS', RESEED, 0)");
        }


        [TestMethod]
        public async Task CreateProduct_ValidProduct_NoExceptionThrown()
        {
            // Arrange
            var productRepository = new ProductRepository(_context);

            var orderRepositoryMock = new Mock<IOrderRepository>();

            var unitOfWork = new UnitOfWork(_context, orderRepositoryMock.Object, productRepository);

            var productService = new ProductService(unitOfWork);

            var product = new Product
            {
                Name = "Cafe",
                Price = 200
            };

            // Act
            await productService.AddNewProductAsync(product);

            // Assert
            Assert.IsNotNull(productRepository.GetProductByID(1));
        }
    }
}
