using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Phoenix.Integration.Test.Developers.Patryk.GeneratedModels
{
    [TestClass]
    public class ColumnNameToPropertyTest
    {
        [TestMethod]
        public void ConvertWhenNoUnderline()
        {
            string columnName = "agenda";
            string propertyName = FirstLetterToUpper(columnName);
            Assert.AreEqual(propertyName,"Agenda");
        }

        [TestMethod]
        public void ConvertWhenUnderline()
        {
            string columnName = "id_courses_list";
            var splitColumnName = columnName.Split('_');
            for (int i = 0; i < splitColumnName.Length; i++)
            {
                splitColumnName[i] = FirstLetterToUpper(splitColumnName[i]);
            }
            string propertyName = string.Join("",splitColumnName); 

            Assert.AreEqual(propertyName, "IdCoursesList");
        }

        private string FirstLetterToUpper(string str)
        {
            return char.ToUpper(str[0]) + str.Substring(1);
        }
         
    }
}