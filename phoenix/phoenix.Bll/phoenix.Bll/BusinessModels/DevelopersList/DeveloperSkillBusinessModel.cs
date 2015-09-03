using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;

namespace Phoenix.Bll.BusinessModels.DevelopersList
{
    public class DeveloperSkillBusinessModel : SkillBusinessModel, IDeveloperSkillBusinessModel
    {
        public int IdUsers { get; set; }
        public double SkillLevel { get; set; }
    }
}