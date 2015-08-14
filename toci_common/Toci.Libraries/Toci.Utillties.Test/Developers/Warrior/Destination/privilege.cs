using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Toci.Utilities.Test.Developers.Warrior.Destination
{
    public class privilege : Model
    {
        public privilege() : base("privilege")
        {
        }
         
        public const string ID = "id";
        public System.String id
            {
                get
                {
                     return (System.String) Fields[ID].GetValue();
                }
                set
                {
                    SetValue(ID, value);
                }
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
            return new privilege();
        }
    }
}
