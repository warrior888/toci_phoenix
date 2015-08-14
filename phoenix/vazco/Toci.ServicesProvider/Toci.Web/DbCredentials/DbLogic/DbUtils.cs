using System;
using System.Collections.Generic;
using DbCredentials.DbLogic.CredentialsModels;
using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace DbCredentials.DbLogic
{
    public class DbUtils
    {
        protected const string TableName = "Projects";

        protected Dictionary<string, Func<string, bool>> primaryKeys = new Dictionary<string, Func<string, bool>>
        {
            {"Projects", columnName => columnName.ToLower().Equals("projectid")},
            {"Scopes", columnName => columnName.ToLower().Equals("scopeid")},
        };

        protected Dictionary<string, Func<Model, Model>> ModelsDictionary = new Dictionary<string, Func<Model, Model>>
        {
            {"Projects", ProjectsModel},
            {"Scopes", ScopesModel}
        };

        protected Dictionary<string, Action<Model>> defaultValues = new Dictionary<string, Action<Model>>
        {
            {
                "Projects", (model) =>
                        {
                            var refModel = (Projects) model;
                            refModel.projectid = default(int);
                        }
            },
            {
                "Scopes", (model) => 
                        {
                            var refModel = (Scopes) model;
                            refModel.scopeid = default(int);
                        }
            },
        };

        protected static Model ScopesModel(Model model)
        {
            var refModel = (Scopes)model;
            var newModel = new Scopes {scopename = refModel.scopename};
            return newModel;
        }

        protected static Model ProjectsModel(Model model)
        {
            var refModel = (Projects)model;
            var newModel = new Projects
            {
                projectname = refModel.projectname,
                projectdata = refModel.projectdata,
                projectauthor = refModel.projectauthor,
                modificationdate = refModel.modificationdate,
                hash = refModel.hash,
                scopeid = refModel.scopeid
            };
            return newModel;
        }

        public void SetDefaultValue(Model model)
        {
            defaultValues[model.GetTableName()](model);
        }

        public void WhereClause(Model model, string columnName)
        {
            model.SetWhere(columnName.ToLower());

            if (primaryKeys[model.GetTableName()](columnName.ToLower()))
            {
                model.SetPrimaryKey(columnName.ToLower());
            }
        }

        public Model GetNewModel(Model model)
        {
            return ModelsDictionary[model.GetTableName()](model);
        }

        public void ModficateDate(Model model)
        {
            if (model.GetTableName().Equals(TableName))
            {
                var newmodel = (Projects)model;
                newmodel.modificationdate = DateTime.Now;
            }
        }

        public void Encrypt(Model model)
        {
            if (model.GetTableName().Equals("Projects"))
            {
                model.EncryptModel();
            }
        }

        public List<IModel> Decrypt(List<IModel> listOfModels, string tableName)
        {
            return tableName.Equals("Projects") ? listOfModels.DecryptModels() : listOfModels;
        }
    }
}