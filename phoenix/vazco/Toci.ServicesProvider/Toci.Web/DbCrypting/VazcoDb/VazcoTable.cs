using System;
using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace DbCrypting
{
    public class VazcoTable : Model
    {
        public VazcoTable() : base("VazcoTable")
        {
        }
         
        public const string ID = "id";
        public Int32 id
            {
                get
                {
                     return (Int32) Fields[ID].GetValue();
                }
                set
                {
                    SetValue(ID, value);
                }
            }
         
        public const string DATA = "data";
        public String data
            {
                get
                {
                     return (String) Fields[DATA].GetValue();
                }
                set
                {
                    SetValue(DATA, value);
                }
            }
         
        public const string NAME = "name";
        public String name
            {
                get
                {
                     return (String) Fields[NAME].GetValue();
                }
                set
                {
                    SetValue(NAME, value);
                }
            }
         
        public const string ADDINGTIME = "addingtime";
        public DateTime addingTime
            {
                get
                {
                     return (DateTime) Fields[ADDINGTIME].GetValue();
                }
                set
                {
                    SetValue(ADDINGTIME, value);
                }
            }
         
        public const string HASH = "hash";
        public String hash
            {
                get
                {
                     return (String) Fields[HASH].GetValue();
                }
                set
                {
                    SetValue(HASH, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new VazcoTable();
        }
        
    }
}
