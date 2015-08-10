using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace DbCredentials.DbLogic.CredentialsModels
{
    public class ProjectAccess : Model
    {
        public ProjectAccess() : base("ProjectAccess")
        {
        }
         
        public const string ACCESSID = "accessid";
        public System.Int32 accessid
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
         
        public const string USERID = "userid";
        public System.Int32 userid
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
        

        protected override IModel GetInstance()
        {
            return new ProjectAccess();
        }
    }
}
