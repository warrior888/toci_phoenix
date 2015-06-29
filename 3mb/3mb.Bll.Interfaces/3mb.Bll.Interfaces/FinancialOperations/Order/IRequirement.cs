using _3mb.Bll.Interfaces.FinancialOperations.Decision;
using _3mb.Bll.Interfaces.User;

namespace _3mb.Bll.Interfaces.FinancialOperations.Order
{
    public interface IRequirement
    {
        IDecision Decision { get; } // ????

        // IPurchase GetPurchase(); for IsApproved == true
        decimal Price { get; }

        I3MbUser User { get; }

        bool IsApproved();
    }
}