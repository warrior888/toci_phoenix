using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.PatrykGeneratedModels
{
    public class portfolio : Model
    {
        public portfolio() : base("portfolio")
        {
        }
         
        public const string ID = "id";
        public System.Int32 id
            {
                get
                {
                     return (System.Int32) Fields[ID].GetValue();
                }
                set
                {
                    SetValue(ID, value);
                }
            }
         
        public const string PROJECT_NAME = "project_name";
        public System.String project_name
            {
                get
                {
                     return (System.String) Fields[PROJECT_NAME].GetValue();
                }
                set
                {
                    SetValue(PROJECT_NAME, value);
                }
            }
         
        public const string PROJECT_COMPLETION_DATE = "project_completion_date";
        public System.DateTime project_completion_date
            {
                get
                {
                     return (System.DateTime) Fields[PROJECT_COMPLETION_DATE].GetValue();
                }
                set
                {
                    SetValue(PROJECT_COMPLETION_DATE, value);
                }
            }
         
        public const string FK_ID_USERS = "fk_id_users";
        public System.Int32 fk_id_users
            {
                get
                {
                     return (System.Int32) Fields[FK_ID_USERS].GetValue();
                }
                set
                {
                    SetValue(FK_ID_USERS, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new portfolio();
        }
    }
}
