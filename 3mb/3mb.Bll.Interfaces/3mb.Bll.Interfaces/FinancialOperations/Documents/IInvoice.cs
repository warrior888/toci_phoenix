using _3mb.Bll.Interfaces.FinancialOperations.Order;

namespace _3mb.Bll.Interfaces.FinancialOperations.Documents
{
    public interface IInvoice : IFinancialDocument
    {
        IOrder Order { get; }

        decimal TotalPrice { get; }

        bool IsInvoiceOrderPriceCorrect(); // totalprice == totalprice ?
    }
}