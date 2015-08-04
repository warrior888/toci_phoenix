using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace DbCredentials.CredentialsModels
{
    public class Projects : Model
    {
        public Projects() : base("Projects")
        {
        }
         
        public const string PROJECTID = "projectid";
        public System.Int32 projectid
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
         
        public const string SCOPEID = "scopeid";
        public System.Int32 scopeid
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
         
        public const string PROJECTNAME = "projectname";
        public System.String projectname
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
         
        public const string PROJECTDATA = "projectdata";
        public System.String projectdata
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
