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
        public System.Int32 scopeid
            {
                get
                {
                     return (System.Int32) Fields[SCOPEID].GetValue();
                }
                set
                {
                    SetValue(SCOPEID, value);
                }
            }
         
        public const string SCOPENAME = "scopename";
        public System.String scopename
            {
                get
                {
                     return (System.String) Fields[SCOPENAME].GetValue();
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
