using System;
using System.Collections.Generic;
using System.Data;
using Phoenix.Bll.BusinessModels.DevelopersList;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;
using Phoenix.Bll.Interfaces.Logic.DevelopersList;
using Phoenix.Dal.GeneratedModels;
using Toci.Db.DbVirtualization;

namespace Phoenix.Bll.Logic.DevelopersList
{
    public class DeveloperListLogic : DbLogic, IDeveloperListLogic
    {
        public IDeveloperBusinessModel GetDevById(int id)
        {
            DeveloperBusinessModel devModelResult = new DeveloperBusinessModel();


            //developers_list

            var developer = GetOneRowById<developers_list>("id", SelectClause.Equal, id);
            if (developer == null) return null;
            //developers_available

            var developerAvailable = GetOneRowById<developers_available>("id", SelectClause.Equal, developer.FkIdDevelopersAvaible);
            if (developerAvailable == null) return null;
            //
            return null;
        }

        public IEnumerable<IDeveloperBusinessModel> GetAllDevelopers()
        {
            var model = new developers_list();

            return null;
        }

    }
}