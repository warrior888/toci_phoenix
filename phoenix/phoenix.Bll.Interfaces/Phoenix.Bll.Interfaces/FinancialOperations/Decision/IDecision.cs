using System.Collections.Generic;
using Toci.Utilities.Interfaces.User;
using _3mb.Bll.Interfaces.FinancialOperations.Order;
using _3mb.Bll.Interfaces.User;

namespace _3mb.Bll.Interfaces.FinancialOperations.Decision
{
    public interface IDecision
    {
        IPhoenixUser Requestor { get; }

        IRequirement Requirement { get; } // ?

        // stopnie zaszeregowania w podjeciu decyzji
        Dictionary<ClassificationLevel, Dictionary<int, IUser>> ClassificationLevels { get; }

        bool IsApproved();
    }
}