namespace Toci.Utilities.Interfaces.Generator.DatabaseModelGenerator
{
    public interface IModelGenerator
    {
        //string GetModelClass(string secludedDdl, string ddlItemsSeparator, out string tableName);
        string GetModelClass(string secludedDdl, string ddlItemsSeparator, out string tableName);

        /*
         * create table dsa (bdashfadvbfhdsbgfs, dsafad, dfsafgds, fdsgsf);
         */ 
    }
}
