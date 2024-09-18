using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;
using InventoryMgmt.Model;
using System.Collections.Generic;

namespace InventoryMgmtQA.Model
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void TestAddValidProduct()
        {
            // Test for adding a valid product
            Product product = new()
            {
                ProductID = 1,
                Name = "ValidProduct",
                QuantityInStock = 10,
                Price = 99.99M
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(product, null, null);
            bool isProductValid = Validator.TryValidateObject(product, context, results, true);
            Assert.IsTrue(isProductValid);
        }

        [TestMethod]
        public void TestAddProductWithEmptyName()
        {
            // Test to ensure adding a product with an empty name is invalid
            Product product = new()
            {
                ProductID = 2,
                Name = "", // Empty name
                QuantityInStock = 10,
                Price = 50.0M
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(product, null, null);
            bool isProductValid = Validator.TryValidateObject(product, context, results, true);
            Assert.IsFalse(isProductValid);
        }

        [TestMethod]
        public void TestAddProductWithNegativeQuantity()
        {
            // Test to ensure a negative quantity is invalid
            Product product = new()
            {
                ProductID = 3,
                Name = "TestProduct",
                QuantityInStock = -1, // Negative quantity
                Price = 20.0M
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(product, null, null);
            bool isProductValid = Validator.TryValidateObject(product, context, results, true);
            Assert.IsFalse(isProductValid);
        }

        [TestMethod]
        public void TestAddProductWithNegativePrice()
        {
            // Test to ensure a product with a negative price is invalid
            Product product = new()
            {
                ProductID = 4,
                Name = "TestProduct",
                QuantityInStock = 10,
                Price = -10.0M // Negative price
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(product, null, null);
            bool isProductValid = Validator.TryValidateObject(product, context, results, true);
            Assert.IsFalse(isProductValid);
        }

        [TestMethod]
        public void TestAddProductWithExcessiveNameLength()
        {
            // Test to ensure a product with a name that exceeds 255 characters is invalid
            Product product = new()
            {
                ProductID = 5,
                Name = new string('A', 256), // Name longer than 255 characters
                QuantityInStock = 5,
                Price = 30.0M
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(product, null, null);
            bool isProductValid = Validator.TryValidateObject(product, context, results, true);
            Assert.IsFalse(isProductValid);
        }

        [TestMethod]
        public void TestAddProductWithMaximumPrice()
        {
            // Test to ensure a product with a valid maximum price is valid
            Product product = new()
            {
                ProductID = 6,
                Name = "TestProduct",
                QuantityInStock = 1,
                Price = decimal.MaxValue // Maximum decimal value
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(product, null, null);
            bool isProductValid = Validator.TryValidateObject(product, context, results, true);
            Assert.IsTrue(isProductValid);
        }

        [TestMethod]
        public void TestAddProductWithMaximumQuantity()
        {
            // Test to ensure a product with the maximum quantity is valid
            Product product = new()
            {
                ProductID = 7,
                Name = "TestProduct",
                QuantityInStock = int.MaxValue, // Maximum integer value
                Price = 15.0M
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(product, null, null);
            bool isProductValid = Validator.TryValidateObject(product, context, results, true);
            Assert.IsTrue(isProductValid);
        }
    }
}
