using System;
using Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons;
using Toci.Base.Abstract.Generator.Interfaces.LogicSkeleton.DdlHandling;

namespace Toci.Base.Abstract.Generator.LogicSkeleton.DdlHandling
{
    public class SingleDdlParser : SingleDdlParserBase
    {
        /// <summary>
        /// Gets information for REFERENCE part of statement
        /// </summary>
        /// <param name="entry">Single ddl statement</param>
        /// <returns>Information of REFERENCE</returns>
        protected override string GetReferenceInformation(string entry)
        {
            throw new NotImplementedException();
        }
    }
}