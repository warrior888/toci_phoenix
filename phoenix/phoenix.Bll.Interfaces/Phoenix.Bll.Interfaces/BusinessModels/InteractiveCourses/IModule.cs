using System.Collections.Generic;

namespace Phoenix.Bll.Interfaces.BusinessModels.InteractiveCourses
{
    public interface IModule<T>
    {
        int Id { get; set; }

        List<T> Submodules { get; set; }
    }

}