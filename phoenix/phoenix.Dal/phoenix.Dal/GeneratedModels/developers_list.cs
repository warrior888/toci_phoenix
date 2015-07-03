using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.GeneratedModels
{
    public class developers_list : Model
    {
        public developers_list() : base("developers_list")
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
         
        public const string ID_USERS = "id_users";
        public System.Int32 id_users
            {
                get
                {
                     return (System.Int32) Fields[ID_USERS].GetValue();
                }
                set
                {
                    SetValue(ID_USERS, value);
                }
            }
         
        public const string SCORE = "score";
        public System.Double score
            {
                get
                {
                     return (System.Double) Fields[SCORE].GetValue();
                }
                set
                {
                    SetValue(SCORE, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new developers_list();
        }
    }
}
