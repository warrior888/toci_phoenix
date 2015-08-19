﻿using System.Collections.Generic;
﻿using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;
﻿using Phoenix.Bll.Interfaces.Logic.DevelopersList;
﻿using Phoenix.Dal.GeneratedModels;
﻿using Toci.Db.DbVirtualization;

namespace Phoenix.Bll.Logic.DevelopersList
{
    public class DeveloperListLogic : DbLogic, IDeveloperListLogic
    {        
        public IEnumerable<IDeveloperBusinessModel> GetAllDevelopers()
        {
            return GetAllElements<IDeveloperBusinessModel, developer_list_view>();
        }

        public IDeveloperBusinessModel GetDevByUserId(int id)
        {
            IDeveloperBusinessModel developer = GetElementsByColumnValue<IDeveloperBusinessModel, developer_list_view, int>("user_id",
                    SelectClause.Equal, id)[0];
            return developer;

        }

    }
}