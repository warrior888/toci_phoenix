using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace DbCredentials.Dal.GeneratedModels
{
    public class Scopes : Model
    {
        public Scopes() : base("Scopes")
        {
        }
         
        public const string SCOPEID = "scopeid";
        public int ScopeId
            {
                get
                {
                     return GetValue<int>(SCOPEID);
                }
                set
                {
                    SetValue(SCOPEID, value);
                }
            }
         
        public const string SCOPENAME = "scopename";
        public string ScopeName
            {
                get
                {
                     return GetValue<string>(SCOPENAME);
                }
                set
                {
                    SetValue(SCOPENAME, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new Scopes();
        }
    }
}
