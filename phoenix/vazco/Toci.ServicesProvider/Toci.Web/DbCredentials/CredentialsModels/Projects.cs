using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace DbCredentials.CredentialsModels
{
    public class Projects : Model
    {
        public Projects() : base("Projects")
        {
        }
         
        public const string PROJECTID = "ProjectID";
        public System.Int32 ProjectID
            {
                get
                {
                     return (System.Int32) Fields[PROJECTID].GetValue();
                }
                set
                {
                    SetValue(PROJECTID, value);
                }
            }
         
        public const string SCOPEID = "ScopeID";
        public System.Int32 ScopeID
            {
                get
                {
                     return (System.Int32) Fields[SCOPEID].GetValue();
                }
                set
                {
                    SetValue(SCOPEID, value);
                }
            }
         
        public const string PROJECTNAME = "ProjectName";
        public System.String ProjectName
            {
                get
                {
                     return (System.String) Fields[PROJECTNAME].GetValue();
                }
                set
                {
                    SetValue(PROJECTNAME, value);
                }
            }
         
        public const string PROJECTDATA = "ProjectData";
        public System.String ProjectData
            {
                get
                {
                     return (System.String) Fields[PROJECTDATA].GetValue();
                }
                set
                {
                    SetValue(PROJECTDATA, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new Projects();
        }
    }
}
