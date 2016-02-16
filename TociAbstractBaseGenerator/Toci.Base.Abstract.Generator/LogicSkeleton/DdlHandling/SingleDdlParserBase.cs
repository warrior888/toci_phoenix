using System;
using Toci.Base.Abstract.Generator.ConfigurationSkeletons;
using Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons;
using Toci.Base.Abstract.Generator.Interfaces.LogicSkeleton.DdlHandling;
using Toci.Extensions.String.Ddl;

namespace Toci.Base.Abstract.Generator.LogicSkeleton.DdlHandling
{
    public abstract class SingleDdlParserBase : ISingleDdlParser
    {
        private const char Separator = ',';
        private const char OpeningBracket = '(';
        private const char ClosingBracket = ')';
        /// <summary>
        /// Parses a single data definition language command to an instance of the given Table
        /// </summary>
        /// <param name="ddl">Single command of ddl in string</param>
        /// <returns>instance of parsed table</returns>
        public virtual IDatabaseTableConfiguration GetTableModel(string ddl) 
        {
            /*
             * create table lookup (
	id serial primary key,
	id_lookup_type int references lookup_type (id),
	name text
); */
            if (ddl.IsCreate())
            {
                var rows = ExtractRows(ddl);

                foreach (var row in rows)
                {
                    // TODO create column config from ddl row
                    // row = id serial primary key   |   id_last_whatever integer references sometable(some_column)
                    var record = new DatabaseColumnConfiguration();
                    

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
            // wycinamy to co wewnatrz nawiasow
            int firstBracketIndex = ddl.IndexOf(OpeningBracket);
            int lastBracketIndex = ddl.LastIndexOf(ClosingBracket);

            //GetDdlBracketPositions(ddl, out firstBracketIndex, out lastBracketIndex);

            ddl = ddl.Remove(0, firstBracketIndex);
            ddl = ddl.Remove(lastBracketIndex);
            return ddl.Split(Separator);
        }

        protected virtual void GetDdlBracketPositions(string str, out int beginingPos, out int endPosition)
        {
            beginingPos = 0;
            endPosition = str.Length;

            for (int i = 0, j = str.Length; i < str.Length; i++, j--)
            {
                if (str[i] == OpeningBracket)
                {
                    beginingPos = i;
                }

                if (str[j] == ClosingBracket)
                {
                    endPosition = j;
                }
            }
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