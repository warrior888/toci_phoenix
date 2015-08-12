using System.Collections.Generic;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;
using Phoenix.Bll.Interfaces.Logic.DevelopersList;
using Phoenix.Dal.GeneratedModels;

namespace Phoenix.Bll.Logic.DevelopersList
{
    public class DeveloperListLogic : DbLogic, IDeveloperListLogic
    {
        public IDeveloperBusinessModel GetDevById(int id)
        {
            var devListModel = new developers_list();
            devListModel.SetWhere("id_users");

            var devList = DbHandle.GetData(devListModel).Tables[0].Columns[0];

           var test = devList.Tables.IndexOf("id_users").Columns[0].ToString();


            return null;
        }

        public IEnumerable<IDeveloperBusinessModel> GetAllDevelopers()
        {
            var model = new developers_list();

            return null;
        }

    }
}