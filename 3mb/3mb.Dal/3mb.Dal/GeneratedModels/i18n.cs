using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace _3mb.Dal.GeneratedModels
{
    public class i18n : Model
    {
        public i18n() : base("i18n")
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
         
        public const string ID_LANGUAGE = "id_language";
        public System.Int32 id_language
            {
                get
                {
                     return (System.Int32) Fields[ID_LANGUAGE].GetValue();
                }
                set
                {
                    SetValue(ID_LANGUAGE, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new i18n();
        }
    }
}
