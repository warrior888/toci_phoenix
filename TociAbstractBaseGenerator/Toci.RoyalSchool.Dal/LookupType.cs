using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Toci.RoyalSchool.Dal
{
    public class LookupType : Model
    {
        public LookupType() : base("LookupType")
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
            return new LookupType();
        }
    }
}
