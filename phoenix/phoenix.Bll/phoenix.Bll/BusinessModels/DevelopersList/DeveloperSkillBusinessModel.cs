using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;

namespace Phoenix.Bll.BusinessModels.DevelopersList
{
    public class DeveloperSkillBusinessModel : IDeveloperSkillBusinessModel
    {
        public int IdUsers { get; set; }
        public string SkillName { get; set; }
        public double SkillLevel { get; set; }
    }
}