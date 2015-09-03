using System;
using Phoenix.Bll.Interfaces.BusinessModels.InteractiveCourses;

namespace Phoenix.Bll.Interfaces.BusinessModels.UsersList
{
    public interface IUsersBusinessModel
    {
        int Id { get; set; }

        string Nick { get; set; }

        string Name { get; set; }

        string Surname { get; set; }

        decimal AccountBalance { get; set; }
        IProgress Progress { get; set; } 

    }
}