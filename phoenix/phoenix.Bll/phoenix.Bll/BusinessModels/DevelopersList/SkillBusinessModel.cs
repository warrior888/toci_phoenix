using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;

namespace Phoenix.Bll.BusinessModels.DevelopersList
{
    public class SkillBusinessModel : ISkillBusinessModel
    {
        public int IdUsers { get; set; }
        public string SkillName { get; set; }
        public double SkillLevel { get; set; }
    }
}