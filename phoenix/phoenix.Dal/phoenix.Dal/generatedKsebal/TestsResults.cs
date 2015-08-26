using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.GeneratedModels
{
    public class TestsResults : Model
    {
        public TestsResults() : base("TestsResults")
        {
        }
         
        public const string FK_ID_APPLICATIONTESTS = "fk_id_applicationtests";
        public int FkIdApplicationtests
            {
                get
                {
                     return GetValue<int>(FK_ID_APPLICATIONTESTS);
                }
                set
                {
                    SetValue(FK_ID_APPLICATIONTESTS, value);
                }
            }
         
        public const string ID_USER = "id_user";
        public string IdUser
            {
                get
                {
                     return GetValue<string>(ID_USER);
                }
                set
                {
                    SetValue(ID_USER, value);
                }
            }
         
        public const string RESULT = "result";
        public string Result
            {
                get
                {
                     return GetValue<string>(RESULT);
                }
                set
                {
                    SetValue(RESULT, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new TestsResults();
        }
    }
}
