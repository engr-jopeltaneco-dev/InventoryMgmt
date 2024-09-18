using InventoryMgmt.Interface;
using InventoryMgmt.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace InventoryMgmt.Service
{
    public class InventoryManager : IInventoryManager
    {
        private readonly List<Product> _products = new();
        private int _currentID = 1;

        // Add a new product to the inventory
        public void AddNewProduct(string name, int quantity, decimal price)
        {
            var product = new Product
            {
                ProductID = _currentID++,
                Name = name,
                QuantityInStock = quantity,
                Price = price
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(product, null, null);
            if (!Validator.TryValidateObject(product, context, results, true))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return;
            }

            _products.Add(product);
            Console.WriteLine("Product added successfully.");
        }

        // Remove a product by its ID
        public void RemoveProduct(int productId)
        {
            var product = _products.FirstOrDefault(p => p.ProductID == productId);
            if (product == null)
            {
                Console.WriteLine("Invalid product ID.");
                return;
            }
            _products.Remove(product);
            Console.WriteLine("Product removed successfully.");
        }

        // Update a product's quantity and price by its ID
        public void UpdateProduct(int productId, int newQuantity, decimal newPrice)
        {
            var product = _products.FirstOrDefault(p => p.ProductID == productId);
            if (product == null)
            {
                Console.WriteLine("Invalid product ID.");
                return;
            }

            product.QuantityInStock = newQuantity;
            product.Price = newPrice;
            Console.WriteLine("Product updated successfully.");
        }

        // Get the total value of the inventory
        public void GetTotalValue()
        {
            decimal totalValue = _products.Sum(p => p.QuantityInStock * p.Price);
            Console.WriteLine($"Total inventory value is: {totalValue:C}");
        }

        // List all products in the inventory
        public void ListProducts()
        {
            if (_products.Count == 0)
            {
                Console.WriteLine("No products found");
                return;
            }

            foreach (var product in _products)
            {
                Console.WriteLine($"ID: {product.ProductID}, Name: {product.Name}, Quantity: {product.QuantityInStock}, Price: {product.Price:C}");
            }
        }
    }
}
