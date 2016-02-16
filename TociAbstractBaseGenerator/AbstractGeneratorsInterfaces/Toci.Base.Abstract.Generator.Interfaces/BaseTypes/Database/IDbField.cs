namespace Toci.Base.Abstract.Generator.Interfaces.BaseTypes.Database
{
    public interface IDbField<T>
    {
        string GetColumnName();
        T GetValue();
        bool IsWhere();
        bool IsPrimaryKey();
        SelectClause GetSelectClause();
        void SetValue(T value);
        void SetWhere(bool isWhere);
        void SetPrimary(bool isPrimary);
        void SetSelectClause(SelectClause clause);
        // constraints ? references not null ?
    }
}