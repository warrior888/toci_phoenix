using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace UnitTestProject.res
{
    public class technologies : Model
    {
        public technologies() : base("technologies")
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
         
        public const string NAME_VERSION = "name_version";
        public string NameVersion
            {
                get
                {
                     return GetValue<string>(NAME_VERSION);
                }
                set
                {
                    SetValue(NAME_VERSION, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new technologies();
        }
    }
}
