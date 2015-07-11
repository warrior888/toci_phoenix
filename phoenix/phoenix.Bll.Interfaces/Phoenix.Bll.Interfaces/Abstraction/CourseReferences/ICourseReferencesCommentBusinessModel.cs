namespace Phoenix.Bll.Interfaces.BusinessModels.CourseReferences
{
    public interface ICourseReferencesCommentBusinessModel
    {
        int CommentId { get; set; }

        int CourseReferenceId { get; set; }

        //IDeveloperListBusinessModel 
        int UserId { get; set; }

        string Comment { get; set; } 
    }
}