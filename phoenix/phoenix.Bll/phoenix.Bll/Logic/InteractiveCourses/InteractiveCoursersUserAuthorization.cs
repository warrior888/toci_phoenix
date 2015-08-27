using Phoenix.Bll.Interfaces.Logic.InteractiveCourses;

namespace Phoenix.Bll.Logic.InteractiveCourses
{
    public class InteractiveCoursersUserAuthorization : IInteractiveCoursesUserAuthorization
    {
        public bool CheckUserAccountBalance(int userId)
        {
            //get user balance from db
            //check if above 0 or limit (optional)
            //if valid return true
            return true; 
        }
    }
}