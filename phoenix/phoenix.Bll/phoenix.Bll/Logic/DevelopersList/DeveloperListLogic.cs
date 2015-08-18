﻿using System;
﻿using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public IDeveloperBusinessModel GetDevById(int id)
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