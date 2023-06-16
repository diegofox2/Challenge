using Challenge.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Challenge.Domain.Test
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void Validate_ValidProduct_NoExceptionThrown()
        {
            // Arrange
            var product = new Product
            {
                ID = 1,
                Name = "Sample Product",
                Price = 10.99m
            };

            // Act & Assert
            try
            {
                product.Validate();
            }
            catch (ApplicationException)
            {
                Assert.Fail("Unexpected exception was thrown.");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void Validate_EmptyName_ThrowsException()
        {
            // Arrange
            var product = new Product
            {
                ID = 1,
                Name = string.Empty,
                Price = 10.99m
            };

            // Act & Assert
            product.Validate();
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void Validate_ZeroPrice_ThrowsException()
        {
            // Arrange
            var product = new Product
            {
                ID = 1,
                Name = "Sample Product",
                Price = 0
            };

            // Act & Assert
            product.Validate();
        }
    }
}


