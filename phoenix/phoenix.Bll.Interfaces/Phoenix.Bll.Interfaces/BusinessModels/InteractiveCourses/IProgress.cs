using System.Collections.Generic;

namespace Phoenix.Bll.Interfaces.BusinessModels.InteractiveCourses
{
    public interface IProgress 
    {
        List<IResult> UsersProgress { get; set; }
    }
}