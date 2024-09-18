using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMgmt.Interface
{
    public interface IOperationManager
    {

        void StartOperation(int operationId);

        void AddOperation(string operationName);


        void RemoveOperation(int operationId);


        void UpdateOperation(int operationId, string newOperationName);
    }
}