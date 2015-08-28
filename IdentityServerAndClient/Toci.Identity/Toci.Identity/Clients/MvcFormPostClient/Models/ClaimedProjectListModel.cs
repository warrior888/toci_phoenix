using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace MvcFormPostClient.Models
{
    public class ClaimedProjectListModel
    {
        public ClaimedProjectListModel()
        {
            var list = System.Security.Claims.ClaimsPrincipal.Current.Claims;
            projects = list.Where(x => x.Type == "project").Select(x => x.Value.ToString()).ToList();
            CreatePermission = list.Any(x => x.Value == "Create" && x.Type == "role");
            EditPermission = list.Any(x => x.Value == "Edit" && x.Type == "role");
            DeletePermission = list.Any(x => x.Value == "Delete" && x.Type == "role");
           
        }


        public IEnumerable<string> projects;
        public bool CreatePermission;
        public bool EditPermission;
        public bool DeletePermission;
    }
}