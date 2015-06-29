
using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace _3mb.Dal.User
{
    public class Privilege : Model
    {
        public Privilege() : base("privilege")
        {
        }

        public const string NAME = "name";
        public System.String name
            {
                get
                {
                     return (System.String) Fields[NAME].GetValue();
                }
                set
                {
                    SetValue(NAME, value);
                }
            }

        protected override IModel GetInstance()
        {
            return  new Privilege();
        }
    }
}
