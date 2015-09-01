using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.GeneratedModels
{
    public class lessons : Model
    {
        public lessons() : base("lessons")
        {
        }
         
        public const string ID = "id";
        public int Id
            {
                get
                {
                     return GetValue<int>(ID);
                }
                set
                {
                    SetValue(ID, value);
                }
            }
         
        public const string LESSON_NAME = "lesson_name";
        public string LessonName
            {
                get
                {
                     return GetValue<string>(LESSON_NAME);
                }
                set
                {
                    SetValue(LESSON_NAME, value);
                }
            }
         
        public const string ID_MODULES = "id_modules";
        public int IdModules
            {
                get
                {
                     return GetValue<int>(ID_MODULES);
                }
                set
                {
                    SetValue(ID_MODULES, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new lessons();
        }
    }
}
