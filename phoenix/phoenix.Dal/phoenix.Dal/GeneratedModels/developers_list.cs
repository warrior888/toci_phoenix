using System;
using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.GeneratedModels
{
    public class developers_list : Model
    {
        public developers_list() : base("developers_list")
        {
        }
         
         
        public const string EXPERIENCE_FROM = "experience_from";
        public DateTime ExperienceFrom
            {
                get
                {
                     return GetValue<DateTime>(EXPERIENCE_FROM);
                }
                set
                {
                    SetValue(EXPERIENCE_FROM, value);
                }
            }
         
        public const string ID_USERS = "id_users";
        public int IdUsers
            {
                get
                {
                     return GetValue<int>(ID_USERS);
                }
                set
                {
                    SetValue(ID_USERS, value);
                }
            }
         
        public const string FK_ID_DEVELOPERS_AVAIBLE = "fk_id_developers_avaible";
        public int FkIdDevelopersAvaible
            {
                get
                {
                     return GetValue<int>(FK_ID_DEVELOPERS_AVAIBLE);
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
