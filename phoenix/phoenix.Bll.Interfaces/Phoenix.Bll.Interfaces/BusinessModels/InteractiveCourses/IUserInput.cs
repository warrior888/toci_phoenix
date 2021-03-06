﻿using Phoenix.Bll.Interfaces.BusinessModels.UsersList;

namespace Phoenix.Bll.Interfaces.BusinessModels.InteractiveCourses
{
    public interface IUserInput
    {
        string Code { get; set; }
        IUsersBusinessModel User { get; set; }
        int TimeSpent { get; set; }
        ITask Task { get; set; } 
    }
}