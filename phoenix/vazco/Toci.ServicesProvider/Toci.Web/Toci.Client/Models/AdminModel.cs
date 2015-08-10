using System.Collections;
using System.Collections.Generic;

namespace Toci.Client.Models
{
    public class AdminModel
    {
        public AdminModel()
        {
            UserDataList = new List<UserModel>(); 
        }

        public IEnumerable<UserModel> UserDataList { get; set; }
    }
}