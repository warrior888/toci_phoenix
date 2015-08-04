using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace DbCredentials.CredentialsModels
{
    public class ProjectAcces : Model
    {
        public ProjectAcces() : base("ProjectAcces")
        {
        }
         
        public const string ACCESSID = "AccessID";
        public System.Int32 AccessID
            {
                get
                {
                     return (System.Int32) Fields[ACCESSID].GetValue();
                }
                set
                {
                    SetValue(ACCESSID, value);
                }
            }
         
        public const string USERID = "UserID";
        public System.Int32 UserID
            {
                get
                {
                     return (System.Int32) Fields[USERID].GetValue();
                }
                set
                {
                    SetValue(USERID, value);
                }
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
        

        protected override IModel GetInstance()
        {
            return new ProjectAcces();
        }
    }
}
