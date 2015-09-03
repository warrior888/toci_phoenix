using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.GeneratedModels
{
    public class modules : Model
    {
        public modules() : base("modules")
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
         
        public const string MODULE_NAME = "module_name";
        public string ModuleName
            {
                get
                {
                     return GetValue<string>(MODULE_NAME);
                }
                set
                {
                    SetValue(MODULE_NAME, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new modules();
        }
    }
}
