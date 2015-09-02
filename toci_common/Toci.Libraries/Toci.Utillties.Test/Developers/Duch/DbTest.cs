using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Db.DbVirtualization.MsSqlQuery;
using Toci.Db.DbVirtualization.PostgreSqlQuery;

namespace Toci.Utilities.Test.Developers.Duch
{
	[TestClass]
	public class DbTest
	{
		[TestMethod]
		public void TestMssqlDelete()
		{
			MsSqlDelete sqlDelete = new MsSqlDelete();
			PostgreSqlDelete postDelete = new PostgreSqlDelete();
            MsSqlInsert ins = new MsSqlInsert();

			TestModel tM = new TestModel("tejbelnejm");

			tM.AddIsWhere("first",5,true);
			tM.AddIsWhere("second", "value", true);
			tM.AddIsWhere("firstFalse", 5, false);
			tM.AddIsWhere("rhird", 55, true);
			tM.AddIsWhere("secondFalse", 14, false);
			var resultSql = sqlDelete.GetQuery(tM);
			var resultPost = postDelete.GetQuery(tM);
		    var resultInsert = ins.GetQuery(tM);

            Assert.AreEqual("delete from tejbelnejm where first = 5 AND second = 'value' AND rhird = 55;", resultSql);
			Assert.AreEqual("delete from tejbelnejm where first = 5 AND second = 'value' AND rhird = 55;", resultPost);
            Assert.AreEqual("insert into tejbelnejm (first,second,firstFalse,rhird,secondFalse) values (5,'value',5,55,14);", resultInsert);
		}
	}
}
