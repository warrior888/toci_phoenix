using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace UnitTestProject.res
{
    public class requirements : Model
    {
        public requirements() : base("requirements")
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
         
        public const string TAG = "tag";
        public string Tag
            {
                get
                {
                     return GetValue<string>(TAG);
                }
                set
                {
                    SetValue(TAG, value);
                }
            }
         
        public const string ID_TECHNOLOGIES = "id_technologies";
        public int IdTechnologies
            {
                get
                {
                     return GetValue<int>(ID_TECHNOLOGIES);
                }
                set
                {
                    SetValue(ID_TECHNOLOGIES, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new requirements();
        }
    }
}
