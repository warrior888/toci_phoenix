namespace Phoenix.Bll.Interfaces.BusinessModels.InteractiveCourses
{
    public interface IResult
    {
        IUserInput Input { get; set; }
        IOutput CompilationOutput { get; set; }
    }
}