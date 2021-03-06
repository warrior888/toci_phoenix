﻿using System;
using System.Collections.Generic;
using Phoenix.Bll.Interfaces.BusinessModels.TeamLeasing;
using Phoenix.Bll.Interfaces.BusinessModels.UsersList;

namespace Phoenix.Bll.Interfaces.BusinessModels.DevelopersList
{
    public interface IDeveloperBusinessModel
    {
        IUsersBusinessModel User { get; set; }

        double Score { get; set; }

        DateTime ExperienceFrom { get; set; }

        IDeveloperAvailableBusinessModel DeveloperAvailable { get; set; }

        IEnumerable<IDeveloperSkillBusinessModel> Skills { get; set; }

        IEnumerable<IPortfolioBusinessModel> Portfolio { get; set; }
    }
}