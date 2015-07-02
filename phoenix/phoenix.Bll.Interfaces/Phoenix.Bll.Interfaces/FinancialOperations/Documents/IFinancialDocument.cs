using Toci.Utilities.Interfaces;
using _3mb.Bll.Interfaces.Document;
using _3mb.Bll.Interfaces.FinancialOperations.Contractor;

namespace _3mb.Bll.Interfaces.FinancialOperations.Documents
{
    public interface IFinancialDocument : I3MbDocument//, IDocumentResource
    {
        IContractor Contractor { get; }
    }
}