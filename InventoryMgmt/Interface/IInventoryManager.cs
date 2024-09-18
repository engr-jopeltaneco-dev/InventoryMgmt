using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMgmt.Interface
{
    public interface IInventoryManager
    {
        void AddNewProduct(string name, int quantity, decimal price);
        void RemoveProduct(int productId);
        void UpdateProduct(int productId, int newQuantity, decimal newPrice);
        void GetTotalValue();
        void ListProducts();
    }
}
