using System;
using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace DbCredentials.DbLogic.CredentialsModels
{
    public class Scopes : Model
    {
        public Scopes() : base("Scopes")
        {
            //scopename = null;
            //scopeid = default(int);
        }
         
        public const string SCOPEID = "scopeid";
        public Int32 scopeid
            {
                get
                {
                     return (Int32) Fields[SCOPEID].GetValue();
                }
                set
                {
                    SetValue(SCOPEID, value);
                }
            }
         
        public const string SCOPENAME = "scopename";
        public String scopename
            {
                get
                {
                     return (String) Fields[SCOPENAME].GetValue();
                }
                set
                {
                    SetValue(SCOPENAME, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new Scopes();
        }
    }
}
