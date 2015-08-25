﻿using System;
using Phoenix.Bll.Interfaces.BusinessModels.TeamLeasing;

namespace Phoenix.Bll.BusinessModels.TeamLeasing
{
    public class DeveloperAvailableBusinessModel : IDeveloperAvailableBusinessModel
    {
        public int Id { get; set; }
        public DateTime AvailableFor { get; set; }
        public float StartWorkHour { get; set; }
        public float EndWorkHour { get; set; }
    }
}