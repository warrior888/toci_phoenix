using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.GeneratedModels
{
    public class course_technologies : Model
    {
        public course_technologies() : base("course_technologies")
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
         
        public const string ID_SKILLS_TECHNOLOGIES = "id_skills_technologies";
        public System.Int32 IdSkillsTechnologies
            {
                get
                {
                     return GetValue<System.Int32>(ID_SKILLS_TECHNOLOGIES);
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
