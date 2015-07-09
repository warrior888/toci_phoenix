using System.Collections.Generic;

namespace Phoenix.Bll.Interfaces.BusinessModels.CourseReferences
{
    public interface ICourseReferencesBusinessModel
    {
        int ReferenceId { get; set; }

        int CourseId { get; set; } 

        //IDeveloperListBusinessModel 
        int UserId { get; set; }

        string References { get; set; }

        IEnumerable<ICourseReferencesCommentBusinessModel> ReferencesComments { get; set; } 
    }
}