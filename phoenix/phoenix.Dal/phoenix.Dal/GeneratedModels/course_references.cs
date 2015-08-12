using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.GeneratedModels
{
    public class course_references : Model
    {
        public course_references() : base("course_references")
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
         
        public const string ID_USERS = "id_users";
        public int IdUsers
            {
                get
                {
                     return GetValue<int>(ID_USERS);
                }
                set
                {
                    SetValue(ID_USERS, value);
                }
            }
         
        public const string REFERENCES_TEXT = "references_text";
        public string ReferencesText
            {
                get
                {
                     return GetValue<string>(REFERENCES_TEXT);
                }
                set
                {
                    SetValue(REFERENCES_TEXT, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new course_references();
        }
    }
}
