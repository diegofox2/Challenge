using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge.Domain.Test
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void Validate_ValidOrder_NoExceptionThrown()
        {
            // Arrange
            var order = new Order
            {
                CustomerID = 1,
                Product = new Product
                {
                    ID = 1
                },
                Quantity = 2,
            };

            // Act & Assert
            try
            {
                order.Validate();
            }
            catch (ApplicationException)
            {
                Assert.Fail("Unexpected exception was thrown.");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void Validate_NullProduct_ThrowsException()
        {
            // Arrange
            var order = new Order
            {
                CustomerID = 1,
                Product = null,
                Quantity = 2
            };

            // Act & Assert
            order.Validate();
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void Validate_NoQuantity_ThrowsException()
        {
            // Arrange
            var order = new Order
            {
                CustomerID = 1,
                Product = new Product
                {
                    ID = 1
                }
            };

            // Act & Assert
            order.Validate();
        }
    }
}
