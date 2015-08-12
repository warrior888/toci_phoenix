namespace Toci.Utilities.Interfaces.Generator.DatabaseModelGenerator
{
    public interface IModelsGenerator
    {
        void GenerateModels(IWrapperModel model, string separator, string ddlItemsSeparator);

        // (); cr (); , , , 
    }
}
