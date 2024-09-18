using InventoryMgmt.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMgmt.Service
{
    public class OperationManager : IOperationManager
    {
        private readonly IInventoryManager _inventoryManager = new InventoryManager();
        private readonly Dictionary<int, string> _operations = new(); // Storing operations with ID

        public void StartOperation(int operationId)
        {
            switch (operationId)
            {
                case 1:
                    Console.Write("Enter Product Name: ");
                    string? name = Console.ReadLine();
                    if (string.IsNullOrEmpty(name))
                    {
                        Console.WriteLine("Product name cannot be empty.");
                        return;
                    }

                    Console.Write("Enter Product Quantity: ");
                    string? quantityInput = Console.ReadLine();
                    if (!int.TryParse(quantityInput, out int quantity))
                    {
                        Console.WriteLine("Invalid quantity. Please enter a valid number.");
                        return;
                    }

                    Console.Write("Enter Product Price: ");
                    string? priceInput = Console.ReadLine();
                    if (!decimal.TryParse(priceInput, out decimal price))
                    {
                        Console.WriteLine("Invalid price. Please enter a valid decimal value.");
                        return;
                    }

                    _inventoryManager.AddNewProduct(name, quantity, price);
                    break;

                case 2:
                    Console.Write("Enter Product ID to Remove: ");
                    string? removeIdInput = Console.ReadLine();
                    if (!int.TryParse(removeIdInput, out int removeId))
                    {
                        Console.WriteLine("Invalid Product ID.");
                        return;
                    }

                    _inventoryManager.RemoveProduct(removeId);
                    break;

                case 3:
                    Console.Write("Enter Product ID to Update: ");
                    string? updateIdInput = Console.ReadLine();
                    if (!int.TryParse(updateIdInput, out int updateId))
                    {
                        Console.WriteLine("Invalid Product ID.");
                        return;
                    }

                    Console.Write("Enter New Quantity: ");
                    string? newQuantityInput = Console.ReadLine();
                    if (!int.TryParse(newQuantityInput, out int newQuantity))
                    {
                        Console.WriteLine("Invalid quantity.");
                        return;
                    }

                    Console.Write("Enter New Price: ");
                    string? newPriceInput = Console.ReadLine();
                    if (!decimal.TryParse(newPriceInput, out decimal newPrice))
                    {
                        Console.WriteLine("Invalid price.");
                        return;
                    }

                    _inventoryManager.UpdateProduct(updateId, newQuantity, newPrice);
                    break;

                case 4:
                    _inventoryManager.GetTotalValue();
                    break;

                case 5:
                    _inventoryManager.ListProducts();
                    break;

                default:
                    Console.WriteLine("Invalid operation ID.");
                    break;
            }
        }

        // Implementation of AddOperation
        public void AddOperation(string operationName)
        {
            int newOperationId = _operations.Count + 1;
            _operations.Add(newOperationId, operationName);
            Console.WriteLine($"Operation '{operationName}' added with ID: {newOperationId}");
        }

        // Implementation of RemoveOperation
        public void RemoveOperation(int operationId)
        {
            if (_operations.Remove(operationId))
            {
                Console.WriteLine($"Operation with ID: {operationId} removed.");
            }
            else
            {
                Console.WriteLine("Invalid operation ID.");
            }
        }

        // Implementation of UpdateOperation
        public void UpdateOperation(int operationId, string newOperationName)
        {
            if (_operations.ContainsKey(operationId))
            {
                _operations[operationId] = newOperationName;
                Console.WriteLine($"Operation with ID: {operationId} updated to '{newOperationName}'.");
            }
            else
            {
                Console.WriteLine("Invalid operation ID.");
            }
        }
    }
}