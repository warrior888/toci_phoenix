using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;

namespace Phoenix.Bll.BusinessModels.DevelopersList
{
    public class SkillBusinessModel : ISkillBusinessModel
    {
        public int Id { get; set; }

        public string SkillName { get; set; }       
    }
}