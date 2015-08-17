namespace Phoenix.Bll.Interfaces.BusinessModels.DevelopersList
{
    public interface IDeveloperSkillBusinessModel
    {
        int IdUsers { get; set; }

        string SkillName { get; set; }

        double SkillLevel { get; set; }
    }
}