using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.PatrykGeneratedModels
{
    public class developers_avaibl : Model
    {
        public developers_avaibl() : base("developers_avaibl")
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
         
        public const string AVAILBLE_FOR = "availble_for";
        public System.DateTime availble_for
            {
                get
                {
                     return (System.DateTime) Fields[AVAILBLE_FOR].GetValue();
                }
                set
                {
                    SetValue(AVAILBLE_FOR, value);
                }
            }
         
        public const string START_WORK_HOUR = "start_work_hour";
        public System.Int32 start_work_hour
            {
                get
                {
                     return (System.Int32) Fields[START_WORK_HOUR].GetValue();
                }
                set
                {
                    SetValue(START_WORK_HOUR, value);
                }
            }
         
        public const string END_WORK_HOUR = "end_work_hour";
        public System.Int32 end_work_hour
            {
                get
                {
                     return (System.Int32) Fields[END_WORK_HOUR].GetValue();
                }
                set
                {
                    SetValue(END_WORK_HOUR, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new developers_avaibl();
        }
    }
}
