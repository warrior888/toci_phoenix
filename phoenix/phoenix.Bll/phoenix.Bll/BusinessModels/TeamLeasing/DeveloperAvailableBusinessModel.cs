using System;
using Phoenix.Bll.Interfaces.BusinessModels.TeamLeasing;

namespace Phoenix.Bll.BusinessModels.TeamLeasing
{
    public class DeveloperAvailableBusinessModel : IDeveloperAvailableBusinessModel
    {
        public int Id { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime AvailableTo { get; set; }
        public float StartWorkHour { get; set; }
        public float EndWorkHour { get; set; }
    }
}