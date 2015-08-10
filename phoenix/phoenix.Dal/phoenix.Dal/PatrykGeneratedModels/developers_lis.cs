using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.PatrykGeneratedModels
{
    public class developers_lis : Model
    {
        public developers_lis() : base("developers_lis")
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
         
        public const string EXPERIENCE_FROM = "experience_from";
        public System.DateTime experience_from
            {
                get
                {
                     return (System.DateTime) Fields[EXPERIENCE_FROM].GetValue();
                }
                set
                {
                    SetValue(EXPERIENCE_FROM, value);
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
         
        public const string FK_ID_DEVELOPERS_AVAIBLE = "fk_id_developers_avaible";
        public System.Int32 fk_id_developers_avaible
            {
                get
                {
                     return (System.Int32) Fields[FK_ID_DEVELOPERS_AVAIBLE].GetValue();
                }
                set
                {
                    SetValue(FK_ID_DEVELOPERS_AVAIBLE, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new developers_lis();
        }
    }
}
