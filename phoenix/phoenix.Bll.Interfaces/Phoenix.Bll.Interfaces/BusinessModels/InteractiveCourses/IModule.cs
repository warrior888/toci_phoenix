using System.Collections.Generic;

namespace Phoenix.Bll.Interfaces.BusinessModels.InteractiveCourses
{
    public interface IModule<TSubmodule, TContent> //TSubmodule ->task lub lesson , TContent -> ITaskContent lub string opis lekcji modułu 
    {
        int Id { get; set; }
        
        List<TSubmodule> Submodules { get; set; }
        TContent Content { get; set; }
    }

}