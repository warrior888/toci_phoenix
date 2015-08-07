using System;
using DbCredentials.DbLogic;
using DbCredentials.DbLogic.CredentialsModels;
using DbCredentials.Logic;

namespace Toci.CredentialsApi.Models
{
    public class SaveModel
    {
        public string columnName { get; set; }
        public string projectName { get; set; }
        public int projectId { get; set; }
        public string projectAuthor { get; set; }
        public string scopeName { get; set; }
        public string projectData { get; set; }

        public bool SaveProject(SaveModel model)
        {
            DbQuery dbQuery =new DbQuery();
            try
            {
                Scopes scmodel = new Scopes
                {
                    scopename = model.scopeName,
                };
                ScopesLogic scopesLogic = new ScopesLogic();
               // scopesLogic.IsScopeExist(scmodel)? ;
               //tu się wypierdala Szyfrant
               // var list dbQuery.Load(scmodel,"scopename");
                Projects prmodel = new Projects
                {
                    projectname = model.projectName,
                    //projectid = model.projectId,
                    projectauthor = model.projectAuthor,
                    projectdata = model.projectData,
                    
                };


                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}