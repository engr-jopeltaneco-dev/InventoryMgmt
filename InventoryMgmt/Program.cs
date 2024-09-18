// See https://aka.ms/new-console-template for more information
using InventoryMgmt.Interface;
using InventoryMgmt.Service;

Console.WriteLine("Welcome to HuanLe Noodles Pte. Ltd. Inventory Management System.");
Console.WriteLine("");

IOperationManager _operationManager = new OperationManager();

while (true)
{
    try
    {
        Console.WriteLine("Inventory Operations:");
        Console.WriteLine("1. Add Product");
        Console.WriteLine("2. Remove Product");
        Console.WriteLine("3. Modify Product");
        Console.WriteLine("4. Get Total Value of Inventory");
        Console.WriteLine("5. Get List of Products");
        Console.WriteLine("----------------------------------------------------------");

        // Read user input and start inventory management operations
        Console.Write("Select an option (1-5): ");
        string? input = Console.ReadLine();

        if (int.TryParse(input, out int operationNo) && operationNo >= 1 && operationNo <= 5)
        {
            _operationManager.StartOperation(operationNo);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid option. Please enter a number between 1 and 5.");
            Console.ResetColor();
        }
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"An error occurred: {ex.Message}");
        Console.ResetColor();
    }
    Console.WriteLine("***");
    Console.WriteLine("");
}
