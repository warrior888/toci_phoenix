namespace Toci.Utilities.Interfaces.Generator.DatabaseModelGenerator
{
    public interface IModelsGenerator
    {
        void GenerateModels(string path, string destinationPath, string separator, string ddlItemsSeparator);

        // (); cr (); , , , 
    }
}
