using System;
using DbCredentials.Bll.Interfaces.BusinessModels;

namespace DbCredentials.Bll.BusinessModel
{
    public class ProjectModel: IProjectModel
    {
        public int ProjectId { get; set; }
        public IScopeModel Scope { get; set; }
        public string ProjectName { get; set; }
        public string ProjectAuthor { get; set; }
        public string ProjectData { get; set; }
        public DateTime ModificationDate { get; set; }
        public string Hash { get; set; }
    }
}