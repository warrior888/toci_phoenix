using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.GeneratedModels
{
    public class AplicationTests : Model
    {
        public AplicationTests() : base("AplicationTests")
        {
        }
         
        public const string CODESNIPET = "codesnipet";
        public string Codesnipet
            {
                get
                {
                     return GetValue<string>(CODESNIPET);
                }
                set
                {
                    SetValue(CODESNIPET, value);
                }
            }
         
        public const string RIGHTANSWERS = "rightanswers";
        public string Rightanswers
            {
                get
                {
                     return GetValue<string>(RIGHTANSWERS);
                }
                set
                {
                    SetValue(RIGHTANSWERS, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new AplicationTests();
        }
    }
}
