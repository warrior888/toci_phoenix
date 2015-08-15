namespace Phoenix.Bll.Interfaces.BusinessModels.InteractiveCourses
{
    public interface IOutput
    {
        string ConsoleOutput { get; set; }
        string CompilationResult { get; set; }
        int ExecutionTimeMs { get; set; }

        IUnitTest UnitTest { get; set; }

    }
}