using System;
using System.Collections.Generic;
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
            var devListModel = new developers_list();
            devListModel.SetWhere("id");
            devListModel.SetSelect("id", SelectClause.Equal);
            var x = devListModel.GetFields();

           // var test = DbHandle.GetData(devListModel).Tables[0].Columns[0];
            return null;
        }

        public IEnumerable<IDeveloperBusinessModel> GetAllDevelopers()
        {
            var model = new developers_list();

            return null;
        }

    }
}