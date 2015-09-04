using DbCredentials.Bll.Interfaces.BusinessModels;

namespace DbCredentials.Bll.BusinessModel
{
    public class ScopeModel: IScopeModel
    {
        public int ScopeId { get; set; }
        public string ScopeName { get; set; }
    }
}