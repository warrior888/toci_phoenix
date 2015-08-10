using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.PatrykGeneratedModels
{
    public class developers_skills : Model
    {
        public developers_skills() : base("developers_skills")
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
         
        public const string SKILL_LEVEL = "skill_level";
        public System.Single skill_level
            {
                get
                {
                     return (System.Single) Fields[SKILL_LEVEL].GetValue();
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
