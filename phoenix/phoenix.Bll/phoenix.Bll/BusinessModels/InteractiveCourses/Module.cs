using System.Collections.Generic;
using Phoenix.Bll.Interfaces.BusinessModels.InteractiveCourses;

namespace Phoenix.Bll.BusinessModels.InteractiveCourses
{
    public class Module 
    {
        public int Id { get; set; }
        public List<Lesson> Submodules { get; set; }
    }
}