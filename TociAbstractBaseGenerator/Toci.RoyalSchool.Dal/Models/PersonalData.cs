using System;
using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Toci.RoyalSchool.Dal
{
    public class PersonalData : Model
    {
        public PersonalData() : base("PersonalData")
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
         
        public const string ID_NAME = "id_name";
        public int IdName
        {
            get
            {
                    return GetValue<int>(ID_NAME);
            }
            set
            {
                SetValue(ID_NAME, value);
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
         
        public const string PESEL = "pesel";
        public string Pesel
        {
            get
            {
                    return GetValue<string>(PESEL);
            }
            set
            {
                SetValue(PESEL, value);
            }
        }
         
        public const string BIRTH_DATE = "birth_date";
        public DateTime BirthDate
        {
            get
            {
                    return GetValue<DateTime>(BIRTH_DATE);
            }
            set
            {
                SetValue(BIRTH_DATE, value);
            }
        }
         
        public const string REGISTRATION_DATE = "registration_date";
        public DateTime RegistrationDate
        {
            get
            {
                    return GetValue<DateTime>(REGISTRATION_DATE);
            }
            set
            {
                SetValue(REGISTRATION_DATE, value);
            }
        }
         
        public const string ADDRESS = "address";
        public string Address
        {
            get
            {
                    return GetValue<string>(ADDRESS);
            }
            set
            {
                SetValue(ADDRESS, value);
            }
        }
        

        protected override IModel GetInstance()
        {
            return new PersonalData();
        }
    }
}
