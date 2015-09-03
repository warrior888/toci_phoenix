using System.Collections.Generic;
using System.Text;
using Toci.Utilities.Interfaces.Generator.DatabaseModelGenerator;
using Toci.Utilities.Interfaces.Generator.DatabaseModelGenerator.DbDdlParser;

namespace Toci.Utilities.Abstraction.Generator.DatabaseModelGenerator
{
    public abstract class ModelGenerator : IModelGenerator
    {
        protected IDdlParser DdlParser;
        protected IModelTemplateProvider TemplateProvider;


        protected ModelGenerator(IDdlParser ddlParser, IModelTemplateProvider templateProvider)
        {
            DdlParser = ddlParser;
            TemplateProvider = templateProvider;
        }

        //  Adnotacja od Robsona: Wydaje mi się, że tą klasę też trzeba napisać bo wiele tu ni ma :) A więc porobię zgodnie z intuicją...jak będzie źle to sorki Panowie. :-)


        public string GetModelClass(string secludedDdl, string ddlItemsSeparator, out string tableName)
        {
            Dictionary<string, IDbFieldEntryEntity> dbFields = DdlParser.GetFieldEntryEntities(secludedDdl, ddlItemsSeparator, out tableName);
            var classBody = GetModelTemplateContent(dbFields);
            TemplateProvider.ClassName = tableName;
            TemplateProvider.BaseConstructorArguments = tableName;
           
            
            return TemplateProvider.GetClass(classBody);
        }

        protected virtual string GetModelTemplateContent(Dictionary<string, IDbFieldEntryEntity> dbFields)
        {
            StringBuilder result = new StringBuilder();
            if(dbFields!=null)
            foreach (var dbFieldEntryEntity in dbFields)
            {
                result.Append(TemplateProvider.GetFilledPropertyTemplate(dbFieldEntryEntity.Value.Name, dbFieldEntryEntity.Value.FieldTypeName));
            }

            return result.ToString();
        }

    }
}
