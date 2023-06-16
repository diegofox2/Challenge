using Challenge.DataAccessLayer.Interfaces;
using Challenge.Domain;
using Moq;

namespace Challenge.ApplicationService.Test.Unit
{
    [TestClass]
    public class ProductServiceTests
    {
        [TestMethod]
        public async Task AddNewProduct_ValidProduct_NoExceptionThrown()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var productRepositoryMock = new Mock<IProductRepository>();
            unitOfWorkMock.SetupGet(uow => uow.ProductRepository).Returns(productRepositoryMock.Object);
            var productService = new ProductService(unitOfWorkMock.Object);

            var product = new Product
            {
                ID = 1,
                Name = "Sample Product",
                Price = 10.99m
            };

            // Act 
            await productService.AddNewProductAsync(product);
            
            //Assert
            productRepositoryMock.Verify(repo => repo.AddProduct(product), Times.Once);
            unitOfWorkMock.Verify(uow => uow.SaveChangesAsync(), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public async Task AddNewProduct_WithNoPrice_ThrowsException()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var productRepositoryMock = new Mock<IProductRepository>();
            unitOfWorkMock.SetupGet(uow => uow.ProductRepository).Returns(productRepositoryMock.Object);
            var productService = new ProductService(unitOfWorkMock.Object);

            var product = new Product
            {
                ID = 1,
                Name = "Sample Product"
            };

            // Act & Assert
            await productService.AddNewProductAsync(product);

        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public async Task AddNewProduct_WithNoName_ThrowsException()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var productRepositoryMock = new Mock<IProductRepository>();
            unitOfWorkMock.SetupGet(uow => uow.ProductRepository).Returns(productRepositoryMock.Object);
            var productService = new ProductService(unitOfWorkMock.Object);

            var product = new Product
            {
                ID = 1,
                Price = 200
            };

            // Act & Assert
            await productService.AddNewProductAsync(product);

        }
    }
}
