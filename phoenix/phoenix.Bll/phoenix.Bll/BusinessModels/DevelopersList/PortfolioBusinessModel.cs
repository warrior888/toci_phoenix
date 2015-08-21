using System;
using System.Collections.Generic;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;

namespace Phoenix.Bll.BusinessModels.DevelopersList
{
    public class PortfolioBusinessModel : IPortfolioBusinessModel
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public IEnumerable<ISkillBusinessModel> Skills { get; set; }
        public int TeamLeaderId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int WeeksSpent
        {
            get
            {
                return 0;
                //return EndDate - StartDate;
            }
        }
    }
}