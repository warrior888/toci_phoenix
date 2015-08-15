using System.Windows.Markup.Localizer;

namespace Phoenix.Bll.Interfaces.BusinessModels.InteractiveCourses
{
    public interface IUnitTest
    {
        string Content { get; set; } 
        string Result { get; set; }
    }
}