using System.Collections.Generic;
using Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons;
using Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons.ModelPatternProviders;
using Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons.ModelTemplates;

namespace Toci.Base.Abstract.Generator.ConfigurationSkeletons
{
    public class DatabaseTableConfiguration : IDatabaseTableConfiguration
    {
        protected IDbModelFilledTemplateProvider DbModelProvider;

        public DatabaseTableConfiguration()
        {
            TableColumns = new Dictionary<string, IDatabaseColumnConfiguration>();
        }

        public string TableName { get; set; }
        // id_last_whatever str below
        public IDictionary<string, IDatabaseColumnConfiguration> TableColumns { get; set; }

        public IDictionary<string, IBusinessLogicConfiguration> TableColumnsBusinessGenerator { get; set; }

        public IDictionary<string, IDatabaseTableConfiguration> ReferencingTables { get; set; }

        public string GenerateDbModel(IModelTemplate template)
        {
            return DbModelProvider.FillTemplate(this, template);
        }
    }
}