using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.GeneratedModels
{
    public class portfolio : Model
    {
        public portfolio() : base("portfolio")
        {
        }
         
        public const string ID = "id";
        public System.Int32 Id
            {
                get
                {
                     return GetValue<System.Int32>(ID);
                }
                set
                {
                    SetValue(ID, value);
                }
            }
         
        public const string PROJECT_NAME = "project_name";
        public System.String ProjectName
            {
                get
                {
                     return GetValue<System.String>(PROJECT_NAME);
                }
                set
                {
                    SetValue(PROJECT_NAME, value);
                }
            }
         
        public const string PROJECT_COMPLETION_DATE = "project_completion_date";
        public System.DateTime ProjectCompletionDate
            {
                get
                {
                     return GetValue<System.DateTime>(PROJECT_COMPLETION_DATE);
                }
                set
                {
                    SetValue(PROJECT_COMPLETION_DATE, value);
                }
            }
         
        public const string FK_ID_USERS = "fk_id_users";
        public System.Int32 FkIdUsers
            {
                get
                {
                     return GetValue<System.Int32>(FK_ID_USERS);
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
