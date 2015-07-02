using System.Collections.Generic;
using _3mb.Bll.Interfaces.FinancialOperations.Order;

namespace _3mb.Bll.Interfaces.FinancialOperations.Contractor
{
    public interface IContractor // : ????
    {
        int GetContractorId();

         // IADres ? adresdData ?
        Dictionary<int, IOrder> Orders { get; } 
    }
}