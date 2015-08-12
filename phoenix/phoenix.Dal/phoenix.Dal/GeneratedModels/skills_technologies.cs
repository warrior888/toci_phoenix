using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.GeneratedModels
{
    public class skills_technologies : Model
    {
        public skills_technologies() : base("skills_technologies")
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
         
        public const string TECH_NAME = "tech_name";
        public string TechName
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
            return new skills_technologies();
        }
    }
}
