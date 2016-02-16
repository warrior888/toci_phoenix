using System.Collections.Generic;

namespace Toci.Base.Abstract.Generator.Interfaces.LogicSkeleton.DdlHandling
{
    public interface IDdlAnalyzer
    {
        
        /// <summary>
        /// Parses ddl to dict
        /// </summary>
        /// <param name="textFile">File cointaining ddls</param>
        /// <returns>ddls from file</returns>
        IList<string> GetAllTablesDdlsSeparated(string textFilePath); // TODO remove method param
        /// <summary>
        /// Parses ddl to dict
        /// </summary>
        /// <param name="fileContent">String of ddl</param>
        /// <returns>ddls from string</returns>
        IList<string> GetAllTablesDdlsSeparatedFromString(string fileContent);
    }
}