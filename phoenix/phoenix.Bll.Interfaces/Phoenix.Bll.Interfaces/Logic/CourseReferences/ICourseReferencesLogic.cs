using System.Collections;
using System.Collections.Generic;
using Phoenix.Bll.Interfaces.BusinessModels.CourseReferences;

namespace Phoenix.Bll.Interfaces.Logic.CourseReferences
{
    public interface ICourseReferencesLogic : IDbLogic
    {
        IEnumerable<ICourseReferencesBusinessModel> GetReferencesByCourseId(int id);

        bool AddComment(ICourseReferencesCommentBusinessModel comment);

        bool RemoveReference(ICourseReferencesBusinessModel reference);

        bool RemoveReferenceComment(ICourseReferencesCommentBusinessModel comment);
    }
}