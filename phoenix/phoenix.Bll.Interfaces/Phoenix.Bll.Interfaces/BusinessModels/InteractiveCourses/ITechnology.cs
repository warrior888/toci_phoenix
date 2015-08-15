using System.Collections.Generic;

namespace Phoenix.Bll.Interfaces.BusinessModels.InteractiveCourses
{
    public interface ITechnology
    {
        string Name { get; set; }
        List<string> Version { get; set; }
    }
}