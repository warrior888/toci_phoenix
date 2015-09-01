using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace UnitTestProject.res
{
    public class levels : Model
    {
        public levels() : base("levels")
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

        public const string LEVEL_OF_TECHNOLOGY = "level_of_technology";
        public int LevelOfTechnology
        {
            get
            {
                return GetValue<int>(LEVEL_OF_TECHNOLOGY);
            }
            set
            {
                SetValue(LEVEL_OF_TECHNOLOGY, value);
            }
        }

        public const string ID_USERS= "id_users";
        public int IdUsers
        {
            get
            {
                return GetValue<int>(ID_USERS);
            }
            set
            {
                SetValue(ID_USERS, value);
            }
        }

        public const string ID_TECHNOLOGIES = "id_technologies";
        public int IdTechnologies
        {
            get
            {
                return GetValue<int>(ID_TECHNOLOGIES);
            }
            set
            {
                SetValue(ID_TECHNOLOGIES, value);
            }
        }


        protected override IModel GetInstance()
        {
            return new levels();
        }
    }
}