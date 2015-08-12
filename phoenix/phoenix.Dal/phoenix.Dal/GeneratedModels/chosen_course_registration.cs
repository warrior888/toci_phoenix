using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.GeneratedModels
{
    public class chosen_course_registration : Model
    {
        public chosen_course_registration() : base("chosen_course_registration")
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
         
        public const string ID_COURSE_REGISTRATION = "id_course_registration";
        public int IdCourseRegistration
            {
                get
                {
                     return GetValue<int>(ID_COURSE_REGISTRATION);
                }
                set
                {
                    SetValue(ID_COURSE_REGISTRATION, value);
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
        

        protected override IModel GetInstance()
        {
            return new chosen_course_registration();
        }
    }
}
