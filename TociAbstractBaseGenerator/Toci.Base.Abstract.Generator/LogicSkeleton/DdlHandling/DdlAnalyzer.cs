using System.Collections.Generic;
using Toci.Base.Abstract.Generator.Interfaces.LogicSkeleton;

namespace Toci.Base.Abstract.Generator.LogicSkeleton
{
    public class DdlAnalyzer : IDdlAnalyzer
    {
        public Dictionary<string, string> GetAllTablesDdlsSeparated(string textFilePath)
        {
            throw new System.NotImplementedException();

        }

        public Dictionary<string, string> GetAllTablesDdlsSeparatedFromString(string fileContent)//a czy nie był by tu potrzebny przykładowy plik?
        {
            throw new System.NotImplementedException();
        }
    }
}