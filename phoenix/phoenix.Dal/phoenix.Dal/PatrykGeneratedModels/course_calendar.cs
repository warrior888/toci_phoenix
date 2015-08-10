using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.PatrykGeneratedModels
{
    public class course_calendar : Model
    {
        public course_calendar() : base("course_calendar")
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
         
        public const string ID_COURSES_LIST = "id_courses_list";
        public System.Int32 id_courses_list
            {
                get
                {
                     return (System.Int32) Fields[ID_COURSES_LIST].GetValue();
                }
                set
                {
                    SetValue(ID_COURSES_LIST, value);
                }
            }
         
        public const string HOURS = "hours";
        public System.Int32 hours
            {
                get
                {
                     return (System.Int32) Fields[HOURS].GetValue();
                }
                set
                {
                    SetValue(HOURS, value);
                }
            }
         
        public const string SESSION_DATE = "session_date";
        public System.DateTime session_date
            {
                get
                {
                     return (System.DateTime) Fields[SESSION_DATE].GetValue();
                }
                set
                {
                    SetValue(SESSION_DATE, value);
                }
            }
         
        public const string AGENDA = "agenda";
        public System.String agenda
            {
                get
                {
                     return (System.String) Fields[AGENDA].GetValue();
                }
                set
                {
                    SetValue(AGENDA, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new course_calendar();
        }
    }
}
