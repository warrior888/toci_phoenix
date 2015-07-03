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
         
        public const string COURSE_NAME = "course_name";
        public System.String course_name
            {
                get
                {
                     return (System.String) Fields[COURSE_NAME].GetValue();
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
