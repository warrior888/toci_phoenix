using System;
using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.GeneratedModels
{
    public class developer_list_view : Model
    {
        public developer_list_view() : base("developer_list_view")
        {
        }

        public const string USER_ID = "user_id";
        public int UserId
        {
            get
            {
                return GetValue<int>(USER_ID);
            }
            set
            {
                SetValue(USER_ID, value);
            }
        }

        public const string NICK = "nick";
        public string Nick
        {
            get
            {
                return GetValue<string>(NICK);
            }
            set
            {
                SetValue(NICK, value);
            }
        }

        public const string NAME = "name";
        public string Name
        {
            get
            {
                return GetValue<string>(NAME);
            }
            set
            {
                SetValue(NAME, value);
            }
        }

        public const string SURNAME = "surname";
        public string Surname
        {
            get
            {
                return GetValue<string>(SURNAME);
            }
            set
            {
                SetValue(SURNAME, value);
            }
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

        public const string SCORE = "score";
        public double Score
        {
            get
            {
                return GetValue<double>(SCORE);
            }
            set
            {
                SetValue(SCORE, value);
            }
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
            return new developer_list_view();
        }
    }
}