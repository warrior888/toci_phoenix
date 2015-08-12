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
         
        public const string EXPERIENCE_FROM = "experience_from";
        public System.DateTime ExperienceFrom
            {
                get
                {
                     return GetValue<System.DateTime>(EXPERIENCE_FROM);
                }
                set
                {
                    SetValue(EXPERIENCE_FROM, value);
                }
            }
         
        public const string ID_USERS = "id_users";
        public System.Int32 IdUsers
            {
                get
                {
                     return GetValue<System.Int32>(ID_USERS);
                }
                set
                {
                    SetValue(ID_USERS, value);
                }
            }
         
        public const string FK_ID_DEVELOPERS_AVAIBLE = "fk_id_developers_avaible";
        public System.Int32 FkIdDevelopersAvaible
            {
                get
                {
                     return GetValue<System.Int32>(FK_ID_DEVELOPERS_AVAIBLE);
                }
                set
                {
                    SetValue(FK_ID_DEVELOPERS_AVAIBLE, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new developers_list();
        }
    }
}
