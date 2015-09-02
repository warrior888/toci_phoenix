using System;
using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Toci.Utilities.Test.Developers.Duch
{
	class TestModel	: Model
	{
		public TestModel(string tableName) : base(tableName)
		{
		}
		public void AddIsWhere<T>(string key, T value, bool isWhere)
		{
			Fields.Add(key, new DbField<object>(key, value, isWhere));
		}

	    protected override IModel GetInstance()
        {   //return model obcject
	        throw new NotImplementedException();
	    }
	}
}
