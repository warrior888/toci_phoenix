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
         
        public const string TECH_NAME = "tech_name";
        public System.String TechName
            {
                get
                {
                     return GetValue<System.String>(TECH_NAME);
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
