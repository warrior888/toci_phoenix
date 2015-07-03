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
         
        public const string TECH_NAME = "tech_name";
        public System.String tech_name
            {
                get
                {
                     return (System.String) Fields[TECH_NAME].GetValue();
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
