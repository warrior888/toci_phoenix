using Phoenix.Bll.Interfaces.BusinessModels.InteractiveCourses;

namespace Phoenix.Bll.Interfaces.Logic.InteractiveCourses
{
    public interface IInteractiveCourseTaskOperations
    {
        bool CheckIfUsersTaskExist(int userId);
        bool InsertUsersFirstRecord(int userId);
        int GetUsersLastTask(int userId);
        ITask GetUsersNextTask(int userId, int lastTasksId);
    }
}