using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace DbCredentials.Logic
{
    public abstract class DbModel: Model
    {
        protected const int lackOfRows = 0;

        protected DbModel(string tableName): base(tableName)
        {
        }

        protected List<object[]> GetTableContent(IModel model, IDbHandle dbhandle)
        {
            var objectList = new List<object[]>();
            var dataSet = dbhandle.GetData(model);
            var tables = dataSet.Tables;
            var rows = tables[tables.Count - 1].Rows;
            if (rows.Count == lackOfRows) return null;
            for (var i = 0; i <= rows.Count - 1; i++)
            {
                var tmp = rows[i].ItemArray;
                objectList.Add(tmp);
            }
            return objectList;
        }

        public List<DbModel> GetDbModelList(IModel model, IDbHandle dbhandle)
        {
            var dbModelList = new List<DbModel>();

            var list = GetTableContent(model, dbhandle);
            foreach (var item in list)
            {
                dbModelList.Add(FillPropertis(item));
            }
            return dbModelList;
        }

        public abstract DbModel FillPropertis(object[] item);
    }

}