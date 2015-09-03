using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.GeneratedModels
{
    public class courses_list : Model
    {
        public courses_list() : base("courses_list")
        {
        }
         
         
        public const string COURSE_NAME = "course_name";
        public string CourseName
            {
                get
                {
                     return GetValue<string>(COURSE_NAME);
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
