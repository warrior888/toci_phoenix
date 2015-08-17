using System.Collections.Generic;

namespace Phoenix.Bll.Interfaces.BusinessModels.InteractiveCourses
{
    public interface ITaskContent
    {
        string Exercise { get; set; }
        List<string> Steps { get; set; }
        List<string> Parameter { get; set; }
        List<string> ReturnType { get; set; }
        //List<string> Hint { get; set; } 
    }
}