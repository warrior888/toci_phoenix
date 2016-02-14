using System;
using Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons;
using Toci.Base.Abstract.Generator.Interfaces.LogicSkeleton.DdlHandling;
using Toci.Extensions.String.Ddl;

namespace Toci.Base.Abstract.Generator.LogicSkeleton.DdlHandling
{
    public abstract class SingleDdlParserBase : ISingleDdlParser
    {
        private const char Separator = ',';
        /// <summary>
        /// Parses a single data definition language command to an instance of the given Table
        /// </summary>
        /// <param name="ddl">Single command of ddl in string</param>
        /// <returns>instance of parsed table</returns>
        public virtual IDatabaseTableConfiguration GetTableModel(string ddl) 
        {
            if (ddl.IsCreate())
            {
                var rows = ExtractRows(ddl);

                foreach (var row in rows)
                {
                    // TODO create column config from ddl row
                }
                //IDatabaseColumnConfiguration
            }

            return null;
        }

        /// <summary>
        /// Extracts one line of the given ddl command
        /// </summary>
        /// <param name="separator">the command separator, commonly ","</param>
        /// <returns>extracted row of a ddl command</returns>
        protected string[] ExtractRows(string ddl)
        {
            return ddl.Split(Separator);
        }
        /// <summary>
        /// Gets the reference information from a command.
        /// </summary>
        /// <param name="entry">A ddl command cointaining a REFERENCES</param>
        /// <returns>Reference information string</returns>
        protected abstract string GetReferenceInformation(string entry);
        /// <summary>
        /// Gets the instance of reference config.
        /// </summary>
        /// <param name="referenceInformation">the reference information, can be get from GetReferenceInformation</param>
        /// <returns>Instance of reference Table configuration</returns>
       // protected abstract IDatabaseTableConfiguration GetReferencingTableConfiguration(string referenceInformation);
    }
}