using Phoenix.Bll.Interfaces.BusinessModels.TeamLeasing;

namespace Phoenix.Bll.Interfaces.Logic.TeamLeasing
{
    public interface IDeveloperAvailableLogic
   {
        IDeveloperAvailableBusinessModel GetDeveloperAvailableById(int id);
    }
}