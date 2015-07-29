using System;
using System.Collections.Generic;
using Toci.Db.Interfaces;

namespace DbCrypting.Logic
{
    public class GenerateDbModelList<T1, T2> where T1: IModel where T2: IDbHandle
    {

        private List<object[]> GetTableContent(T1 model, T2 dbhandle)
        {
            var objectList = new List<object[]>();
            var dataSet = dbhandle.GetData(model);
            var tables = dataSet.Tables;
            var rows = tables[tables.Count - 1].Rows;
            if (rows.Count == 0) return null;
            for (var i = 0; i <= rows.Count - 1; i++)
            {
                var tmp = rows[i].ItemArray;
                objectList.Add(tmp);
            }
            return objectList;
        }

        public List<DbModel> GetDbModelList(T1 model, T2 dbhandle)
        {
            var dbModelList = new List<DbModel>();

            var list = GetTableContent(model, dbhandle);
            foreach (var item in list)
            {
                dbModelList.Add(new DbModel { addingTime = (DateTime)item[2], data = (string)item[0], nick = (string)item[1], hash = (string)item[3] });
            }
            return dbModelList;
        }
    }
}