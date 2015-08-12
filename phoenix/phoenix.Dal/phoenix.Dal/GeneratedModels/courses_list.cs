using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.GeneratedModels
{
    public class courses_list : Model
    {
        public courses_list() : base("courses_list")
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
         
        public const string COURSE_NAME = "course_name";
        public System.String CourseName
            {
                get
                {
                     return GetValue<System.String>(COURSE_NAME);
                }
                set
                {
                    SetValue(COURSE_NAME, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new courses_list();
        }
    }
}
