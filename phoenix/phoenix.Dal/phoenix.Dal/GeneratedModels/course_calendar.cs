using System;
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
        public int Id
            {
                get
                {
                     return GetValue<int>(ID);
                }
                set
                {
                    SetValue(ID, value);
                }
            }
         
        public const string ID_COURSES_LIST = "id_courses_list";
        public int IdCoursesList
            {
                get
                {
                     return GetValue<int>(ID_COURSES_LIST);
                }
                set
                {
                    SetValue(ID_COURSES_LIST, value);
                }
            }
         
        public const string HOURS = "hours";
        public int Hours
            {
                get
                {
                     return GetValue<int>(HOURS);
                }
                set
                {
                    SetValue(HOURS, value);
                }
            }
         
        public const string SESSION_DATE = "session_date";
        public DateTime SessionDate
            {
                get
                {
                     return GetValue<DateTime>(SESSION_DATE);
                }
                set
                {
                    SetValue(SESSION_DATE, value);
                }
            }
         
        public const string AGENDA = "agenda";
        public string Agenda
            {
                get
                {
                     return GetValue<string>(AGENDA);
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
