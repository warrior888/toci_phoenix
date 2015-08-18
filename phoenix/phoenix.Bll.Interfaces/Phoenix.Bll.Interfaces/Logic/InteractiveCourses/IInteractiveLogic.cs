using Phoenix.Bll.Interfaces.BusinessModels.InteractiveCourses;

namespace Phoenix.Bll.Interfaces.Logic.InteractiveCourses
{
    public interface IInteractiveCoursesLogic
    {
        IOutput GetCodeResults(IUserInput userInput);
        ITask GetTask(int taskId);
    }
}