namespace Phoenix.Bll.Interfaces.BusinessModels.DevelopersList
{
    public interface IDeveloperSkillBusinessModel : ISkillBusinessModel
    {
        int IdUsers { get; set; }
        double SkillLevel { get; set; } 
    }
}