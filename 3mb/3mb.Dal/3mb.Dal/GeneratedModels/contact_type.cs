using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace _3mb.Dal.GeneratedModels
{
    public class contact_type : Model
    {
        public contact_type() : base("contact_type")
        {
        }
         
        public const string ID = "id";
        public System.Int32 id
            {
                get
                {
                     return (System.Int32) Fields[ID].GetValue();
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
            return new contact_type();
        }
    }
}
