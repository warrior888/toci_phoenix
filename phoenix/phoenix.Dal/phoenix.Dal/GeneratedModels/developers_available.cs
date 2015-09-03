using System;
using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.GeneratedModels
{
    public class developers_available : Model
    {
        public developers_available() : base("developers_available")
        {
        }
         
         
        public const string AVAILABLE_FROM = "available_from";
        public DateTime AvailableFrom
            {
                get
                {
                     return GetValue<DateTime>(AVAILABLE_FROM);
                }
                set
                {
                    SetValue(AVAILABLE_FROM, value);
                }
            }

        public const string AVAILABLE_TO = "available_to";
        public DateTime AvailableTo
            {
                get
                {
                     return GetValue<DateTime>(AVAILABLE_TO);
                }
                set
                {
                    SetValue(AVAILABLE_TO, value);
                }
            }
         
        public const string START_WORK_HOUR = "start_work_hour";
        public int StartWorkHour
            {
                get
                {
                     return GetValue<int>(START_WORK_HOUR);
                }
                set
                {
                    SetValue(START_WORK_HOUR, value);
                }
            }
         
        public const string END_WORK_HOUR = "end_work_hour";
        public int EndWorkHour
            {
                get
                {
                     return GetValue<int>(END_WORK_HOUR);
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
