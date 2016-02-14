using Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons;

namespace Toci.Base.Abstract.Generator.Interfaces.LogicSkeleton.DdlHandling
{
    public interface ISingleDdlParser
    {
        //zwraca pojedyncza tabele na podstawie ddl
        /// <summary>
        /// Parses single command of data definition language
        /// </summary>
        /// <param name="ddl">String containing the date definition language</param>
        /// <returns>Parsde table form ddl</returns>
        IDatabaseTableConfiguration GetTableModel(string ddl);
    }
}