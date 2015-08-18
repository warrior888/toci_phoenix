﻿using System;
﻿using System.Collections.Generic;
﻿using System.Linq;
﻿using AutoMapper;
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
            List<developer_list_view> developersList = FetchModelsFromDb<developer_list_view>(new developer_list_view());

            return developersList.Select(Mapper.Map<IDeveloperBusinessModel>);
        }

        public IDeveloperBusinessModel GetDevByUserId(int id)
        {

            developer_list_view developerFromDb = FetchModelFromDb<developer_list_view>(new developer_list_view()
            {
                UserId = id
            }.SetSelect("id_users", SelectClause.Equal));

            IDeveloperBusinessModel developer = Mapper.Map<IDeveloperBusinessModel>(developerFromDb);
            return developer;

        }

    }
}