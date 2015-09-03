using System.Collections.Generic;

namespace Phoenix.Bll.Interfaces.BusinessModels.InteractiveCourses
{
    public interface ITask
    {
        int Id { get; set; }
        ITaskContent Content { get; set; }
        int AverageTime { get; set; }
        List<string> UnitTests { get; set; }
    }
}