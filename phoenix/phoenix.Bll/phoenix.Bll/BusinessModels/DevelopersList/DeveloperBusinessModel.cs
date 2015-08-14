using System;
using System.Collections.Generic;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;
using Phoenix.Bll.Interfaces.BusinessModels.TeamLeasing;
using Phoenix.Bll.Interfaces.BusinessModels.UsersList;

namespace Phoenix.Bll.BusinessModels.DevelopersList
{
    public class DeveloperBusinessModel : IDeveloperBusinessModel
    {
        public IUsers User { get; set; }
        public double Score { get; set; }
        public DateTime ExperienceFrom { get; set; }
        public IDeveloperAvailableBusinessModel DeveloperAvailable { get; set; }
        public IEnumerable<ISkillBusinessModel> Skills { get; set; }
        public IEnumerable<IPortfolioBusinessModel> Portfolio { get; set; }
    }
}