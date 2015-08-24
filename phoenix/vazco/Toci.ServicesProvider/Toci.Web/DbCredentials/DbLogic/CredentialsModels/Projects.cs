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
        public Int32 projectid
            {
                get
                {
                     return (Int32) Fields[PROJECTID].GetValue();
                }
                set
                {
                    SetValue(PROJECTID, value);
                }
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
         
        public const string PROJECTNAME = "projectname";
        public String projectname
            {
                get
                {
                     return (String) Fields[PROJECTNAME].GetValue();
                }
                set
                {
                    SetValue(PROJECTNAME, value);
                }
            }

        public const string PROJECTAUTHOR = "projectauthor";
        public String projectauthor
        {
            get
            {
                return (String)Fields[PROJECTAUTHOR].GetValue();
            }
            set
            {
                SetValue(PROJECTAUTHOR, value);
            }
        }

        public const string PROJECTDATA = "projectdata";
        public String projectdata
            {
                get
                {
                     return (String) Fields[PROJECTDATA].GetValue();
                }
                set
                {
                    SetValue(PROJECTDATA, value);
                }
            }

        public const string MODIFICATIONDATE = "modificationdate";
        public DateTime modificationdate
        {
            get
            {
                return (DateTime)Fields[MODIFICATIONDATE].GetValue();
            }
            set
            {
                SetValue(MODIFICATIONDATE, value);
            }
        }

        public const string HASH = "hash";
        public String hash
        {
            get
            {
                return (String)Fields[HASH].GetValue();
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
