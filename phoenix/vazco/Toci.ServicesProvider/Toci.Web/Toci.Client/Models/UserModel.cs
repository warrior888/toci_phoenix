using System.Collections.Generic;

namespace Toci.Client.Models
{
    public class UserModel
    {
       public string id { get; set; }
        public string email { get; set; }
        public ICollection<string> UserRoleList { get; set; }
    }
}