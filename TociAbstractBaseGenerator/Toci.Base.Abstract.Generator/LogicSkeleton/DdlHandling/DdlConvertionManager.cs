using System.Collections;
using System.Collections.Generic;
using Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons;
using Toci.Base.Abstract.Generator.Interfaces.LogicSkeleton.DdlHandling;

namespace Toci.Base.Abstract.Generator.LogicSkeleton.DdlHandling
{
    public class DdlConvertionManager : IDdlConvertionManager
    {
        protected IList<IDatabaseTableConfiguration> databaseTables = new List<IDatabaseTableConfiguration>();

        public void CreateDdlModels(IDdlAnalyzer analyzer, ISingleDdlParser ddlParser)
        {
            var ddlCreatesTable = analyzer.GetAllTablesDdlsSeparated();

            foreach (var ddlCreateTable in ddlCreatesTable)
            {
                databaseTables.Add(ddlParser.GetTableModel(ddlCreateTable));
            }
        }
    }
}