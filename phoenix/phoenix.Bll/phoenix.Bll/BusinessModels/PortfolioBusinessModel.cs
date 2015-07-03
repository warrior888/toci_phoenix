using System;
using System.Collections.Generic;
using Phoenix.Bll.Interfaces.BusinessModels;

namespace Phoenix.Bll.BusinessModels
{
    public class PortfolioBusinessModel : IPortfolioBusinessModel
    {
        public string ProjectName { get; set; }
        public IEnumerable<ISkillBusinessModel> Skills { get; set; }
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