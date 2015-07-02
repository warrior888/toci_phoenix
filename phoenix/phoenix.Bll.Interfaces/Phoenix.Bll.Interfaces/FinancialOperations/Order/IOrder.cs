using System.Collections.Generic;
using _3mb.Bll.Interfaces.FinancialOperations.Contractor;
using _3mb.Bll.Interfaces.FinancialOperations.Decision;

namespace _3mb.Bll.Interfaces.FinancialOperations.Order
{
    public interface IOrder
    {
        decimal TotalPrice { get; }

        IDecision Decision { get; } // Lazy ? List<List > ? ????

        IContractor Contractor { get; }

        // lista purchase po=winnqa sie pokrywac z lista requirement
        Dictionary<int, IPurchase> Purchase { get; }

        Dictionary<int, IRequirement> Requirement { get; }

        int GetOrderId();

        bool IsOrdered();
    }
}