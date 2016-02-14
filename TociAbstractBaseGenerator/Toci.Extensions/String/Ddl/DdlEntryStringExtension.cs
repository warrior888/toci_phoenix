using System.Linq;

namespace Toci.Extensions.String.Ddl
{
    public static class DdlEntryStringExtension
    {
        private const string Insert = "insert";
        private const string Update = "update";
        private const string Select = "select";
        private const string Delete = "delete";
        private const string Create = "create";

       /// <summary>
        /// Checks the given ddl statement for insert.
        /// </summary>
        /// <param name="insertCandidate">DDL statement</param>
        /// <returns>If the given ddl command is an insert</returns>
        public static bool IsInsert(this string insertCandidate)
        {
            return StartsWith(insertCandidate, Insert);
        }
        /// <summary>
        /// Checks the given ddl statement for create
        /// </summary>
        /// <param name="createCandidate">DDL statement</param>
        /// <returns>If the given ddl command is a CREATE</returns>
        public static bool IsCreate(this string createCandidate)
        {
            return StartsWith(createCandidate, Create);
        }
       
        /// <summary>
        /// Checks the given ddl statement for update
        /// </summary>
        /// <param name="updateCandidate">DDL statement</param>
        /// <returns>If the given ddl command is a UPDATE</returns>
        public static bool IsUpdate(this string updateCandidate)
        {
            return StartsWith(updateCandidate, Update);
        }

        /// <summary>
        /// Checks the given ddl statement for delete
        /// </summary>
        /// <param name="deleteCandidate">DDL statement</param>
        /// <returns>If the given ddl command is a Delete</returns>
        public static bool IsDelete(this string deleteCandidate)
        {
            return StartsWith(deleteCandidate, Delete);
        }

        /// <summary>
        /// Checks the given ddl statement for select
        /// </summary>
        /// <param name="selectCandidate">DDL statement</param>
        /// <returns>If the given ddl command is a Select</returns>
        public static bool IsSelect(this string selectCandidate)
        {
            return StartsWith(selectCandidate, Select);
        }

        // TODO update delete select foreign key

        public static bool StartsWith(string candidate, string needle)
        {
            return candidate.ToLower().StartsWith(needle.ToLower());
        }
    }
}