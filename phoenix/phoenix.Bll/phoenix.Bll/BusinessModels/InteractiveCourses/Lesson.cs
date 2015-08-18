using System;
using System.Collections.Generic;
using Phoenix.Bll.Interfaces.BusinessModels.InteractiveCourses;

namespace Phoenix.Bll.BusinessModels.InteractiveCourses
{
    public class Lesson 
    {
        public int Id { get; set; }
        public List<Exercise> Submodules { get; set; }
        
    }
}
