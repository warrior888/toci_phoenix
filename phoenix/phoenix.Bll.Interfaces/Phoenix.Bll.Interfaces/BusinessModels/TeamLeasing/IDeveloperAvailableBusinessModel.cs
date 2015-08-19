using System;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;

namespace Phoenix.Bll.Interfaces.BusinessModels.TeamLeasing
{
    public interface IDeveloperAvailableBusinessModel
    {
        int Id { get; set; }
        DateTime AvailableFor { get; set; }

	    float StartWorkHour { get; set; }

	    float EndWorkHour { get; set; }
    }
}