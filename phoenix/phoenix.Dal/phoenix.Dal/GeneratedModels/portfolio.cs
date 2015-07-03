using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.GeneratedModels
{
    public class portfolio : Model
    {
        public portfolio() : base("portfolio")
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
         
        public const string PROJECT_NAME = "project_name";
        public System.String project_name
            {
                get
                {
                     return (System.String) Fields[PROJECT_NAME].GetValue();
                }
                set
                {
                    SetValue(PROJECT_NAME, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new portfolio();
        }
    }
}
