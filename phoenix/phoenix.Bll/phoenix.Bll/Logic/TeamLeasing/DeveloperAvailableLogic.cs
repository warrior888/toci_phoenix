using Phoenix.Bll.Interfaces.BusinessModels.TeamLeasing;
using Phoenix.Bll.Interfaces.Logic.TeamLeasing;
using Phoenix.Dal.GeneratedModels;

namespace Phoenix.Bll.Logic.TeamLeasing
{
    public class DeveloperAvailableLogic : PhoenixDataAccessLogic, IDeveloperAvailableLogic
    {
        public IDeveloperAvailableBusinessModel GetDeveloperAvailableById(int id)
        {
            return GetElementById<IDeveloperAvailableBusinessModel, developers_available>(id);
        }
    }
}