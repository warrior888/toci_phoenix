using Phoenix.Bll.Interfaces.BusinessModels.InteractiveCourses;
using Phoenix.Bll.Interfaces.BusinessModels.UsersList;
using Toci.Utilities.Interfaces.User;

namespace Phoenix.Bll.BusinessModels.UsersList
{
    public class UsersBusinessModel : IUsersBusinessModel
    {
        public string Nick { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public  decimal AccountBalance { get; set; }
        public IProgress Progress { get; set; }
    }
}