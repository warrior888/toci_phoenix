using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.PatrykGeneratedModels
{
    public class course_technologies : Model
    {
        public course_technologies() : base("course_technologies")
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
         
        public const string ID_SKILLS_TECHNOLOGIES = "id_skills_technologies";
        public System.Int32 id_skills_technologies
            {
                get
                {
                     return (System.Int32) Fields[ID_SKILLS_TECHNOLOGIES].GetValue();
                }
                set
                {
                    SetValue(ID_SKILLS_TECHNOLOGIES, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new course_technologies();
        }
    }
}
