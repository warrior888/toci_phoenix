using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Toci.Utilities.Test.Developers.Warrior.Destination
{
    public class test : Model
    {
        public test() : base("test")
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
         
        public const string NAZWA = "nazwa";
        public System.String nazwa
            {
                get
                {
                     return (System.String) Fields[NAZWA].GetValue();
                }
                set
                {
                    SetValue(NAZWA, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new test();
        }
    }
}
