using DbCredentials.CredentialsModels;

namespace DbCredentials.Logic
{
    public static class InsertDataExtMethods
    {
        public static void FillAddInModel(this ProjectAccess item, ProjectAccess model)
        {
            item.accessid = model.accessid;
            item.projectid = model.projectid;
            item.userid = model.userid;
        }
        
        public static void FillAddInModel(this Projects item, Projects model)
        {
            item.projectid = model.projectid;
            item.scopeid = model.scopeid;
            item.projectname = model.projectname;
            item.projectdata = model.projectdata;
        }
        public static void FillAddInModel(this Users item, Users model)
        {
            item.userid = model.userid;
            item.scopeid = model.scopeid;
            item.userlogin = model.userlogin;
            item.userpassword = model.userpassword;
        }
        
        public static void FillAddInModel(this Scopes item, Scopes model)
        {

        }
    }
}