using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.GeneratedModels
{
    public class course_calendar : Model
    {
        public course_calendar() : base("course_calendar")
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
         
        public const string ID_COURSES_LIST = "id_courses_list";
        public System.Int32 IdCoursesList
            {
                get
                {
                     return GetValue<System.Int32>(ID_COURSES_LIST);
                }
                set
                {
                    SetValue(ID_COURSES_LIST, value);
                }
            }
         
        public const string HOURS = "hours";
        public System.Int32 Hours
            {
                get
                {
                     return GetValue<System.Int32>(HOURS);
                }
                set
                {
                    SetValue(HOURS, value);
                }
            }
         
        public const string SESSION_DATE = "session_date";
        public System.DateTime SessionDate
            {
                get
                {
                     return GetValue<System.DateTime>(SESSION_DATE);
                }
                set
                {
                    SetValue(SESSION_DATE, value);
                }
            }
         
        public const string AGENDA = "agenda";
        public System.String Agenda
            {
                get
                {
                     return GetValue<System.String>(AGENDA);
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
