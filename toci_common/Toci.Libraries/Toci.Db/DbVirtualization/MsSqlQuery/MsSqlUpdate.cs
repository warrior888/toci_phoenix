﻿using System;
using System.Collections.Generic;
using System.Linq;
using Toci.Db.Interfaces;

namespace Toci.Db.DbVirtualization.MsSqlQuery
{
    public class MsSqlUpdate : SqlQuery, IUpdate
    {
        private const string Pattern = "UPDATE {0} SET {1} WHERE {2};";
        private const string AssignmentPattern = "{0} = {1}";
        private const string Comma = ", ";
        private const int MinStatementLength = 2;

        public override string GetQuery(IModel model)
        {
            var where = GetWhereStatement(model);
            if (where.Length < MinStatementLength)
                return "";

            return string.Format(Pattern, model.GetTableName(), GetSetStatement(model), where);
        }

        protected virtual string GetSetStatement(IModel model)
        {
            var list = model.GetFields().Where(x =>!IsObjectDefault(x.Value.GetValue()) && !x.Value.IsPrimaryKey()).
                Select(item => string.Format(AssignmentPattern, item.Key, GetSurroundedValue(item.Value.GetValue()))).
                Cast<object>().ToList();
            return string.Join(Comma, list);
        }

        private bool IsObjectDefault<T>(T obj)
        {
            return obj==null;
        }
    }
}
