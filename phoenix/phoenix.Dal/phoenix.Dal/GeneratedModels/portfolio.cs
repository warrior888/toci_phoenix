using System;
using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.GeneratedModels
{
    public class portfolio : Model
    {
        public portfolio() : base("portfolio")
        {
        }
         
         
        public const string PROJECT_NAME = "project_name";
        public string ProjectName
            {
                get
                {
                     return GetValue<string>(PROJECT_NAME);
                }
                set
                {
                    SetValue(PROJECT_NAME, value);
                }
            }

        public const string PROJECT_START_DATE = "project_start_date";
        public DateTime StartDate
        {
            get
            {
                return GetValue<DateTime>(PROJECT_COMPLETION_DATE);
            }
            set
            {
                SetValue(PROJECT_COMPLETION_DATE, value);
            }
        }

        public const string PROJECT_COMPLETION_DATE = "project_completion_date";
        public DateTime EndDate
            {
                get
                {
                     return GetValue<DateTime>(PROJECT_COMPLETION_DATE);
                }
                set
                {
                    SetValue(PROJECT_COMPLETION_DATE, value);
                }
            }
         
        public const string FK_ID_USERS = "fk_id_users";  //User
        public int TeamLeaderId
            {
                get
                {
                     return GetValue<int>(FK_ID_USERS);
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
