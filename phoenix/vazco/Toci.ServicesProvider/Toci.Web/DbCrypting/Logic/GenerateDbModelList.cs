using System;
using System.Collections.Generic;
using Toci.Db.Interfaces;

namespace DbCrypting.Logic
{
    public class GenerateDbModelList<T1, T2> where T1: IModel where T2: IDbHandle
    {
        private const int lackOfRows = 0;
        private const int idPosition = 0;
        private const int hashPosition = 4;
        private const int timePosition = 3;
        private const int nickPosition = 2;
        private const int dataPosition = 1;





        private List<object[]> GetTableContent(T1 model, T2 dbhandle)
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

//        public List<DbModel> GetDbModelList(T1 model, T2 dbhandle)
//        {
//            var dbModelList = new List<DbModel>();
//
//            var list = GetTableContent(model, dbhandle);
//            foreach (var item in list)
//            {
//                dbModelList.Add(new DbModel
//                {
//                    addingTime = (DateTime)item[timePosition],
//                    data = (string)item[dataPosition],
//                    nick = (string)item[nickPosition],
//                    hash = (string)item[hashPosition],
//                    id = (int)item[idPosition]
//                });
//            }
//            return dbModelList;
//        }
        public List<VazcoTable> GetVazcoList(T1 model, T2 dbhandle)
        {
            var vazcoList = new List<VazcoTable>();

            var list = GetTableContent(model, dbhandle);
            foreach (var item in list)
            {
                vazcoList.Add(new VazcoTable
                {
                    addingTime = (DateTime)item[timePosition],
                    data = (string)item[dataPosition],
                    name = (string)item[nickPosition],
                    hash = (string)item[hashPosition],
                    id = (int)item[idPosition]
                });
            }
            return vazcoList;
        }
    }
}