using System.Data.Entity;
using Toci.Db.EntityFramework;

namespace Toci.Bll.Nfs
{
    public class Dal<TModel> : DalEfClientBase<TModel> where TModel : class
    {
        public Dal(DbContext entitiesDbContext) : base(entitiesDbContext)
        {
        }
    }
}