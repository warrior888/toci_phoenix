using System.Data.Entity;
using Toci.Db.Interfaces;

namespace Toci.Bll.Nfs
{
    public abstract class LogicBase<TModel> where TModel : class
    {
        protected Dal<TModel> Database;

        protected LogicBase(Dal<TModel> context)
        {
            Database = context;
        }
    }
}