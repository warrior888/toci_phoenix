using System;
using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace DbCredentials.Dal.GeneratedModels
{
    public class Projects : Model
    {
        public Projects() : base("Projects")
        {
        }
         
        public const string PROJECTID = "projectid";
        public int ProjectId
            {
                get
                {
                     return GetValue<int>(PROJECTID);
                }
                set
                {
                    SetValue(PROJECTID, value);
                }
            }
         
        public const string SCOPEID = "scopeid";
        public int ScopeId
            {
                get
                {
                     return GetValue<int>(SCOPEID);
                }
                set
                {
                    SetValue(SCOPEID, value);
                }
            }
         
        public const string PROJECTNAME = "projectname";
        public string ProjectName
            {
                get
                {
                     return GetValue<string>(PROJECTNAME);
                }
                set
                {
                    SetValue(PROJECTNAME, value);
                }
            }
         
        public const string PROJECTAUTHOR = "projectauthor";
        public string ProjectAuthor
            {
                get
                {
                     return GetValue<string>(PROJECTAUTHOR);
                }
                set
                {
                    SetValue(PROJECTAUTHOR, value);
                }
            }
         
        public const string PROJECTDATA = "projectdata";
        public string ProjectData
            {
                get
                {
                     return GetValue<string>(PROJECTDATA);
                }
                set
                {
                    SetValue(PROJECTDATA, value);
                }
            }
         
        public const string MODIFICATIONDATE = "modificationdate";
        public DateTime ModificationDate
            {
                get
                {
                     return GetValue<DateTime>(MODIFICATIONDATE);
                }
                set
                {
                    SetValue(MODIFICATIONDATE, value);
                }
            }
         
        public const string HASH = "hash";
        public string Hash
            {
                get
                {
                     return GetValue<string>(HASH);
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
