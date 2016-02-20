using System.Collections;
using System.Collections.Generic;
using Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons.ModelTemplates;

namespace Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons
{
    public interface IDatabaseTableConfiguration
    {
        string TableName { get; set; }

        IDictionary<string, IDatabaseColumnConfiguration> TableColumns { get; set; }

        IDictionary<string, IDatabaseTableConfiguration> ReferencingTables { get; set; }

        // klasa do zapisu do pliku
        /// <summary>
        /// 
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        string GenerateDbModel(IModelTemplate template);
    }
}