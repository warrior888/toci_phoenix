using System;

namespace DbCredentials.Bll.Interfaces.BusinessModels
{
    public interface IProjectModel
    {
        int ProjectId { get; set; }
        IScopeModel Scope { get; set; }
        string ProjectName { get; set; }
        string ProjectAuthor { get; set; }
        string ProjectData { get; set; }
        DateTime ModificationDate { get; set; }
        string Hash { get; set; }
    }
}