using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.GeneratedModels
{
    public class roles : Model
    {
        public roles() : base("roles")
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
         
        public const string NAME = "name";
        public System.String Name
            {
                get
                {
                     return GetValue<System.String>(NAME);
                }
                set
                {
                    SetValue(NAME, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new roles();
        }
    }
}
