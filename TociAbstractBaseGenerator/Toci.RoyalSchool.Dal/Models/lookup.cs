using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Toci.RoyalSchool.Dal
{
    public class Lookup : Model
    {
        public Lookup() : base("Lookup")
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
         
        public const string ID_LOOKUP_TYPE = "id_lookup_type";
        public int IdLookupType
        {
            get
            {
                    return GetValue<int>(ID_LOOKUP_TYPE);
            }
            set
            {
                SetValue(ID_LOOKUP_TYPE, value);
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
        

        protected override IModel GetInstance()
        {
            return new Lookup();
        }
    }
}
