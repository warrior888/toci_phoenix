﻿using System;
﻿using System.Collections.Generic;
﻿using Phoenix.Bll.BusinessModels.DevelopersList;
﻿using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;
﻿using Phoenix.Bll.Interfaces.Logic.DevelopersList;
﻿using Phoenix.Bll.Interfaces.Logic.TeamLeasing;
﻿using Phoenix.Bll.Interfaces.Logic.UsersList;
﻿using Phoenix.Bll.Logic.TeamLeasing;
﻿using Phoenix.Bll.Logic.UsersList;
﻿using Phoenix.Dal.GeneratedModels;
﻿using Toci.Db.DbVirtualization;

namespace Phoenix.Bll.Logic.DevelopersList
{
    public class DeveloperListLogic : DbLogic, IDeveloperListLogic
    {

        //TODO DI + widok
        private IUsersLogic _userLogic = new UsersLogic();
        private IPortfolioLogic _portfolioLogic = new PortfolioLogic();
        private IDeveloperSkillLogic _skillLogic = new DeveloperSkillLogic();
        private IDeveloperAvailableLogic _availableLogic = new DeveloperAvailableLogic();

        public IDeveloperBusinessModel GetDevById(int id)
        {
            IDeveloperBusinessModel developer = new DeveloperBusinessModel();

            developers_list developerFromDb = FetchModelFromDb<developers_list>(new developers_list()
            {
                IdUsers = id
            }.SetSelect("id_users", SelectClause.Equal));


            developer.User = _userLogic.GetUserById(developerFromDb.IdUsers);
            developer.ExperienceFrom = developerFromDb.ExperienceFrom;
            developer.Portfolio = _portfolioLogic.GetUserPortfolio(developerFromDb.IdUsers);
            developer.Skills = _skillLogic.GetUserSkills(developerFromDb.IdUsers);
           /* developer.DeveloperAvailable =
                _availableLogic.GetDeveloperAvailableById(developerFromDb.FkIdDevelopersAvaible);*/
            return developer;

        }

        public IEnumerable<IDeveloperBusinessModel> GetAllDevelopers()
        {
            throw new NotImplementedException();
        }

    }
}