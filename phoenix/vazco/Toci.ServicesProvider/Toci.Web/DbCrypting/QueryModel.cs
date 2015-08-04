using System;
using DbCrypting.Config;
using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace DbCrypting
{
    public class QueryModel : Model
    {
        private const string DataColumnName = "data" ;
        private const string TimeColumnName = "addingTime";
        private const string NickColumnName = "name" ;
        private const string HashColumnName = "hash" ;
        private const string Star = "*" ;
        private static string _tableName  = LoadConfig.TableName;


        public QueryModel() : base(_tableName)
        {
        }

        protected override IModel GetInstance()
        {
            throw new System.NotImplementedException();
        }
        public void AddIsWhere<T>(string key, T value, bool isWhere)
        {
            Fields.Add(key, new DbField<object>(key, value, isWhere));
        }

        public void SetData(string data)
        {
            //SetValue(DataColumnName, data);
            AddIsWhere(DataColumnName,data,false);
        }

        public void SetTime(DateTime time)
        {
            //SetValue(TimeColumnName, time);
            AddIsWhere(TimeColumnName,time,false);
        }

        public  void SetNick(string nick)
        {
            //SetValue(NickColumnName, nick);
            AddIsWhere(NickColumnName,nick,false);
        }
        public void SetHash(string hash)
        {
            //SetValue(HashColumnName, hash);
            AddIsWhere(HashColumnName,hash,false);
        }
        public void SetAll()
        {
            SetValue(Star, Star);
        }

    }
}