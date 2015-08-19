using System;
using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace DbCredentials.DbLogic.CredentialsModels
{
    public class Projects : Model
    {
        public Projects() : base("Projects")
        {
            //projectname = null;
            //projectauthor = null;
            //projectdata = null;
            //projectid = default(int);
            //scopeid = default(int);
            modificationdate = default(DateTime);
            hash = null;
        }

        public const string PROJECTID = "projectid";
        public System.Int32 projectid
            {
                get
                {
                     return (System.Int32) Fields[PROJECTID].GetValue();
                }
                set
                {
                    SetValue(PROJECTID, value);
                }
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
         
        public const string PROJECTNAME = "projectname";
        public System.String projectname
            {
                get
                {
                     return (System.String) Fields[PROJECTNAME].GetValue();
                }
                set
                {
                    SetValue(PROJECTNAME, value);
                }
            }

        public const string PROJECTAUTHOR = "projectauthor";
        public System.String projectauthor
        {
            get
            {
                return (System.String)Fields[PROJECTAUTHOR].GetValue();
            }
            set
            {
                SetValue(PROJECTAUTHOR, value);
            }
        }

        public const string PROJECTDATA = "projectdata";
        public System.String projectdata
            {
                get
                {
                     return (System.String) Fields[PROJECTDATA].GetValue();
                }
                set
                {
                    SetValue(PROJECTDATA, value);
                }
            }

        public const string MODIFICATIONDATE = "modificationdate";
        public System.DateTime modificationdate
        {
            get
            {
                return (System.DateTime)Fields[MODIFICATIONDATE].GetValue();
            }
            set
            {
                SetValue(MODIFICATIONDATE, value);
            }
        }

        public const string HASH = "hash";
        public System.String hash
        {
            get
            {
                return (System.String)Fields[HASH].GetValue();
            }
            set
            {
                SetValue(HASH, value);
            }
        }
        

        protected override IModel GetInstance()
        {
            return new Projects();
        }
    }
}
