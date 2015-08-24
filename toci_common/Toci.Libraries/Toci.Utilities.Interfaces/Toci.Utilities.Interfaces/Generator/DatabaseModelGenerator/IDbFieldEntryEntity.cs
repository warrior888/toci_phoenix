namespace Toci.Utilities.Interfaces.Generator.DatabaseModelGenerator
{
    public interface IDbFieldEntryEntity
    {
        string Name { get; set; } //id

        string FieldTypeName { get; set; }

        // id int primary key

        //constraints, foreign keys
    }
}
