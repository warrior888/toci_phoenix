using System;
using System.Collections.Generic;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;
using Phoenix.Bll.Interfaces.BusinessModels.TeamLeasing;

namespace Phoenix.Bll.BusinessModels.DevelopersList
{
    public class DeveloperBusinessModel : IDeveloperBusinessModel
    {
        public string Nick { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Score { get; set; }
        public DateTime ExperienceFrom { get; set; }
        public IDeveloperAvailableBusinessModel DeveloperAvailable { get; set; }
        public IEnumerable<ISkillBusinessModel> Skills { get; set; }
        public IEnumerable<IPortfolioBusinessModel> Portfolio { get; set; }
    }
}