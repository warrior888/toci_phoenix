using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.GeneratedModels
{
    public class developers_skills : Model
    {
        public developers_skills() : base("developers_skills")
        {
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
         
        public const string ID_SKILLS_TECHNOLOGIES = "id_skills_technologies";
        public int IdSkillsTechnologies
            {
                get
                {
                     return GetValue<int>(ID_SKILLS_TECHNOLOGIES);
                }
                set
                {
                    SetValue(ID_SKILLS_TECHNOLOGIES, value);
                }
            }
         
        public const string SKILL_LEVEL = "skill_level";
        public double SkillLevel
            {
                get
                {
                     return GetValue<double>(SKILL_LEVEL);
                }
                set
                {
                    SetValue(SKILL_LEVEL, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new developers_skills();
        }
    }
}
