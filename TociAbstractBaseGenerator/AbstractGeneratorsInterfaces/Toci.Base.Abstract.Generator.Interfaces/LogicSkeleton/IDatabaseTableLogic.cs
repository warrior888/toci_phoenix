using Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons;

namespace Toci.Base.Abstract.Generator.Interfaces.LogicSkeleton
{
    public interface IDatabaseTableLogic
    {
        /// <summary>
        /// Weź uzupełnij to summary
        /// </summary>
        /// <returns> string createtable...</returns>
        string DatabaseTableDdl();
 
       /// <summary>
       /// 
       /// </summary>
       /// <returns>Configuration for data base table</returns>
        IDatabaseTableConfiguration DatabaseTableConfiguration();
    }
}