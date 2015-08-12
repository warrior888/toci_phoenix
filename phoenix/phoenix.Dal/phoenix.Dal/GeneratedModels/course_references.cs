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
         
        public const string ID_USERS = "id_users";
        public System.Int32 IdUsers
            {
                get
                {
                     return GetValue<System.Int32>(ID_USERS);
                }
                set
                {
                    SetValue(ID_USERS, value);
                }
            }
         
        public const string REFERENCES_TEXT = "references_text";
        public System.String ReferencesText
            {
                get
                {
                     return GetValue<System.String>(REFERENCES_TEXT);
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
