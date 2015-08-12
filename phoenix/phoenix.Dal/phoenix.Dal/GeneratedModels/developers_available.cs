using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.GeneratedModels
{
    public class developers_available : Model
    {
        public developers_available() : base("developers_available")
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
         
        public const string AVAILBLE_FOR = "availble_for";
        public System.DateTime AvailbleFor
            {
                get
                {
                     return GetValue<System.DateTime>(AVAILBLE_FOR);
                }
                set
                {
                    SetValue(AVAILBLE_FOR, value);
                }
            }
         
        public const string START_WORK_HOUR = "start_work_hour";
        public System.Int32 StartWorkHour
            {
                get
                {
                     return GetValue<System.Int32>(START_WORK_HOUR);
                }
                set
                {
                    SetValue(START_WORK_HOUR, value);
                }
            }
         
        public const string END_WORK_HOUR = "end_work_hour";
        public System.Int32 EndWorkHour
            {
                get
                {
                     return GetValue<System.Int32>(END_WORK_HOUR);
                }
                set
                {
                    SetValue(END_WORK_HOUR, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new developers_available();
        }
    }
}
