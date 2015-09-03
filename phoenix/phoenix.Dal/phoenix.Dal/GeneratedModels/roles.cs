using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.GeneratedModels
{
    public class roles : Model
    {
        public roles() : base("roles")
        {
        }
         
        public const string NAME = "name";
        public string Name
            {
                get
                {
                     return GetValue<string>(NAME);
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
