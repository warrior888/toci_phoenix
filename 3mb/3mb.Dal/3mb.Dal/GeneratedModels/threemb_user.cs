using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace _3mb.Dal.GeneratedModels
{
    public class threemb_user : Model
    {
        public threemb_user() : base("threemb_user")
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
         
        public const string ID_THREEMB_USER_PARENT = "id_threemb_user_parent";
        public System.Int32 id_threemb_user_parent
            {
                get
                {
                     return (System.Int32) Fields[ID_THREEMB_USER_PARENT].GetValue();
                }
                set
                {
                    SetValue(ID_THREEMB_USER_PARENT, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new threemb_user();
        }
    }
}
