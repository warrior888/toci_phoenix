using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace DbCrypting.VazcoDb
{
    public class wrappertestTable : Model
    {
        public wrappertestTable() : base("wrappertestTable")
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
         
        public const string DATA = "data";
        public System.String data
            {
                get
                {
                     return (System.String) Fields[DATA].GetValue();
                }
                set
                {
                    SetValue(DATA, value);
                }
            }
         
        public const string NAME = "name";
        public System.String name
            {
                get
                {
                     return (System.String) Fields[NAME].GetValue();
                }
                set
                {
                    SetValue(NAME, value);
                }
            }
         
        public const string ADDINGTIME = "addingtime";
        public System.DateTime addingtime
            {
                get
                {
                     return (System.DateTime) Fields[ADDINGTIME].GetValue();
                }
                set
                {
                    SetValue(ADDINGTIME, value);
                }
            }
         
        public const string HASH = "hash";
        public System.String hash
            {
                get
                {
                     return (System.String) Fields[HASH].GetValue();
                }
                set
                {
                    SetValue(HASH, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new wrappertestTable();
        }
    }
}