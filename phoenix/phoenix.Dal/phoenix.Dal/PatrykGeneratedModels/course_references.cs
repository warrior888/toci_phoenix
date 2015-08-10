using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.PatrykGeneratedModels
{
    public class course_references : Model
    {
        public course_references() : base("course_references")
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
         
        public const string ID_USERS = "id_users";
        public System.Int32 id_users
            {
                get
                {
                     return (System.Int32) Fields[ID_USERS].GetValue();
                }
                set
                {
                    SetValue(ID_USERS, value);
                }
            }
         
        public const string REFERENCES_TEXT = "references_text";
        public System.String references_text
            {
                get
                {
                     return (System.String) Fields[REFERENCES_TEXT].GetValue();
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
