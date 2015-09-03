using Phoenix.Bll.Interfaces.BusinessModels.Payments;

namespace Phoenix.Bll.Interfaces.Logic.Payments
{
    public interface IPaymentsLogic
    {
        bool PerformTransfer(ITransfer transfer); //paypal if success increment users account balance

    }
}