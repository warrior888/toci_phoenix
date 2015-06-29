using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace _3mb.Dal.GeneratedModels
{
    public class geographic_region : Model
    {
        public geographic_region() : base("geographic_region")
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
         
        public const string ID_GEOGRAPHIC_REGION_PARENT = "id_geographic_region_parent";
        public System.Int32 id_geographic_region_parent
            {
                get
                {
                     return (System.Int32) Fields[ID_GEOGRAPHIC_REGION_PARENT].GetValue();
                }
                set
                {
                    SetValue(ID_GEOGRAPHIC_REGION_PARENT, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new geographic_region();
        }
    }
}
