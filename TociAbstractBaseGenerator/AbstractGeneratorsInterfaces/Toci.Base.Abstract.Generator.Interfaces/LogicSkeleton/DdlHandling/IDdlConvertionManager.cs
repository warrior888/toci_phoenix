namespace Toci.Base.Abstract.Generator.Interfaces.LogicSkeleton.DdlHandling
{
    public interface IDdlConvertionManager
    {
        void CreateDdlModels(IDdlAnalyzer analyzer, ISingleDdlParser ddlParser);
    }
}