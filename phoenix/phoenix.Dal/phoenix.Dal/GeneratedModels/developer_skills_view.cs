using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.GeneratedModels
{
    public class developer_skills_view : Model
    {
        public developer_skills_view() : base("developer_skills_view")
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

        public const string TECH_NAME = "tech_name";
        public string SkillName
        {
            get
            {
                return GetValue<string>(TECH_NAME);
            }
            set
            {
                SetValue(TECH_NAME, value);
            }
        }

        protected override IModel GetInstance()
        {
            return new developer_skills_view();
        }
    }
}