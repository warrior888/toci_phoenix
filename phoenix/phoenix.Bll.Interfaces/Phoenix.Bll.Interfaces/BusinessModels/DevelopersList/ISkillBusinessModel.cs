namespace Phoenix.Bll.Interfaces.BusinessModels.DevelopersList
{
    public interface ISkillBusinessModel
    {
        int IdUsers { get; set; }

        string SkillName { get; set; }

        double SkillLevel { get; set; }
    }
}