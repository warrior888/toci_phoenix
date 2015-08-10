using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.PatrykGeneratedModels
{
    public class chosen_course_registration : Model
    {
        public chosen_course_registration() : base("chosen_course_registration")
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
         
        public const string ID_COURSE_REGISTRATION = "id_course_registration";
        public System.Int32 id_course_registration
            {
                get
                {
                     return (System.Int32) Fields[ID_COURSE_REGISTRATION].GetValue();
                }
                set
                {
                    SetValue(ID_COURSE_REGISTRATION, value);
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
        

        protected override IModel GetInstance()
        {
            return new chosen_course_registration();
        }
    }
}
