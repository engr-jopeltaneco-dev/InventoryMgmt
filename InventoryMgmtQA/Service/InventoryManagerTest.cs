using InventoryMgmt.Model;
using InventoryMgmt.Service;
using InventoryMgmt.Interface;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InventoryMgmtQA.Service
{
    [TestClass]
    public class InventoryManagerTest
    {
        private IInventoryManager _inventoryManager = null!;

        [TestInitialize]
        public void Setup()
        {
            _inventoryManager = new InventoryManager();
        }

        [TestMethod]
        public void TestAddProduct_ValidProduct()
        {
            // Test adding a valid product
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                _inventoryManager.AddNewProduct("TestProduct", 10, 15.99M);
                Assert.IsTrue(sw.ToString().Contains("Product added successfully"));
            }
        }

        [TestMethod]
        public void TestAddProduct_InvalidProduct()
        {
            // Test adding a product with invalid attributes
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                _inventoryManager.AddNewProduct("", 1, 1M);
                Assert.IsTrue(sw.ToString().Contains("Name should not be empty"));
            }
        }

        [TestMethod]
        public void TestRemoveProduct_ValidProductId()
        {
            // Test removing a product with a valid ID
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                _inventoryManager.AddNewProduct("TestProduct", 10, 15.99M);
                _inventoryManager.RemoveProduct(1); // Assuming ID 1 was assigned to the added product
                Assert.IsTrue(sw.ToString().Contains("Product removed successfully"));
            }
        }

        [TestMethod]
        public void TestRemoveProduct_InvalidProductId()
        {
            // Test removing a product with an invalid ID
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                _inventoryManager.RemoveProduct(-1);
                Assert.IsTrue(sw.ToString().Contains("Invalid product ID"));
            }
        }

        [TestMethod]
        public void TestUpdateProduct()
        {
            // Test updating an existing product
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                _inventoryManager.AddNewProduct("TestProduct", 10, 15.99M);
                _inventoryManager.UpdateProduct(1, 20, 25.99M); // Assuming ID 1 was assigned to the added product
                Assert.IsTrue(sw.ToString().Contains("Product updated successfully"));
            }
        }

        [TestMethod]
        public void TestGetTotalValue()
        {
            // Test getting the total value of the inventory
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                _inventoryManager.AddNewProduct("TestProduct", 10, 15.99M);
                _inventoryManager.GetTotalValue();
                Assert.IsTrue(sw.ToString().Contains("Total inventory value is"));
            }
        }

        [TestMethod]
        public void TestListProducts()
        {
            // Test listing all products in the inventory
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                _inventoryManager.AddNewProduct("TestProduct", 10, 15.99M);
                _inventoryManager.ListProducts();
                Assert.IsTrue(sw.ToString().Contains("TestProduct"));
            }
        }

        [TestMethod]
        public void TestRemoveProduct_NonExistentProductId()
        {
            // Test removing a product with a non-existent ID
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                _inventoryManager.RemoveProduct(999); // Assuming ID 999 does not exist
                string output = sw.ToString();
                Assert.IsTrue(output.Contains("Invalid product ID"), $"Unexpected output: {output}");
            }
        }

        [TestMethod]
        public void TestUpdateProduct_NonExistentProduct()
        {
            // Test updating a product that does not exist
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                _inventoryManager.UpdateProduct(999, 20, 25.99M); // Assuming ID 999 does not exist
                Assert.IsTrue(sw.ToString().Contains("Invalid product ID"));
            }
        }

        [TestMethod]
        public void TestGetTotalValue_EmptyInventory()
        {
            // Test getting the total value of an empty inventory
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                _inventoryManager.GetTotalValue();
                string output = sw.ToString();
                Assert.IsTrue(output.Contains("Total inventory value is: $0.00"), $"Unexpected output: {output}");
            }
        }

        [TestMethod]
        public void TestListProducts_EmptyInventory()
        {
            // Test listing products in an empty inventory
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                _inventoryManager.ListProducts();
                string output = sw.ToString();
                Assert.IsTrue(output.Contains("No products found"), $"Unexpected output: {output}");
            }
        }

        [TestMethod]
        public void TestAddProduct_MaxProductId()
        {
            // Test adding a product with the maximum allowed ProductID
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                _inventoryManager.AddNewProduct("MaxProduct", int.MaxValue, 99.99M);
                Assert.IsTrue(sw.ToString().Contains("Product added successfully"));
            }
        }

        [TestMethod]
        public void TestAddProduct_MinProductId()
        {
            // Test adding a product with the minimum allowed ProductID
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                _inventoryManager.AddNewProduct("MinProduct", 1, 99.99M);
                Assert.IsTrue(sw.ToString().Contains("Product added successfully"));
            }
        }
    }
}
