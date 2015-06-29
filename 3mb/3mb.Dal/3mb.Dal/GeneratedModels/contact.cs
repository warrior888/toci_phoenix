using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace _3mb.Dal.GeneratedModels
{
    public class contact : Model
    {
        public contact() : base("contact")
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
         
        public const string ID_THREEMB_USER = "id_threemb_user";
        public System.Int32 id_threemb_user
            {
                get
                {
                     return (System.Int32) Fields[ID_THREEMB_USER].GetValue();
                }
                set
                {
                    SetValue(ID_THREEMB_USER, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new contact();
        }
    }
}
