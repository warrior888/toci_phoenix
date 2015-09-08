using System.Collections.Generic;
using System.Linq;
using Toci.Utilities.Common.String;
using Toci.Utilities.Interfaces.Generator.DatabaseModelGenerator;

namespace Toci.Utilities.Abstraction.Generator.DatabaseModelGenerator
{
    public abstract class ModelTemplateProvider : IModelTemplateProvider
    {
        private const string UsingString = "using";

        private string _usings;
        public string Usings
        {
            get { return _usings; }
            set{ _usings = string.Format("{0} {1};",UsingString,value);}
        }

        public string NamespaceName { get; set; }

        public string Parents { get; set; }

        public string ClassName { get; set; }

        public string ClassModifiers { get; set; }

        public string BaseConstructorArguments { get; set; }


        /// <summary>
        /// 0-usings, 1-namespace name, 2- class modifiers, 3-class name, 4-parents (with :), 5- base constructor
        /// 6-properties
        /// </summary>
        private const string DefaultClassPattern =
@"{0}

namespace {1}
{{
    {2} class {3} {4}
    {{
        public {3}() : base(""{5}"")
        {{
        }}
        {6}

        protected override IModel GetInstance()
        {{
            return new {3}();
        }}
    }}
}}
";

        /// <summary>
        /// 0-property name, 1-property type
        /// </summary>
        private const string DefaultPropertyPattern =
        @" 
        public const string {0:U} = ""{0}"";
        public {1} {2}
            {{
                get
                {{
                     return GetValue<{1}>({0:U});
                }}
                set
                {{
                    SetValue({0:U}, value);
                }}
            }}
        ";

        private const string DefaultUsings =
 @"Toci.Db.DbVirtualization;
using Toci.Db.Interfaces";       //.cs    
     


     
        protected string PropertyPattern { get; set; }
        protected string ClassPattern { get; set; }

        protected ModelTemplateProvider(string classModifiers)
        {
            
            ClassModifiers = classModifiers;
            PropertyPattern = DefaultPropertyPattern;
            ClassPattern = DefaultClassPattern;
            Usings = DefaultUsings; 

            NamespaceName = string.Empty;
            Parents = string.Empty;
            ClassName = string.Empty;
            BaseConstructorArguments = string.Empty;

        }

        /// <summary>
        /// Default template params: 0-property name, 1-property type
        /// </summary>
        public string GetFilledPropertyTemplate(params string[] values)
        {
            if (values[0] == "id")
                return "";
            List<string> valuesWithPropName = values.ToList();
            valuesWithPropName.Add(ConvertColumnNameToPropertyName(values[0]));
            return string.Format(new UpperAndLowerStringFormat(), PropertyPattern, valuesWithPropName.ToArray());
        }

        /// <summary>
        /// Default template params:  0-usings, 1-namespac ename, 2- class modifiers, 3-class name, 4-parents (with :)- filled in derivered class, 5-properties as argument
        /// </summary>
        public string GetClass(string contents)
        {


            string parents = Parents != string.Empty ? string.Format(": {0}", Parents) : Parents;
          //  string baseConstructorArguments = BaseConstructorArguments != string.Empty ? string.Format("{0}",BaseConstructorArguments) : BaseConstructorArguments;

            return string.Format(ClassPattern, Usings, NamespaceName, ClassModifiers, ClassName, parents, BaseConstructorArguments, contents);
        }


        //TESTOWA METODA DO USUNIĘCIA
        public string GetClass(params string[]values)
        {
            return string.Format(ClassPattern, values);
            
            
        }

        private string FirstLetterToUpper(string str)
        {
            return char.ToUpper(str[0]) + str.Substring(1);
        }

        private string ConvertColumnNameToPropertyName(string columnName)
        {
            var splitColumnName = columnName.Split('_');
            for (int i = 0; i < splitColumnName.Length; i++)
            {
                splitColumnName[i] = FirstLetterToUpper(splitColumnName[i]);
            }
            return  string.Join("", splitColumnName); 
        }

        // ;)
        private string ConvertSystemTypeNameToNormalTypeName(string typeName)
        {
            switch (typeName)
            {
                case "System.Int32":
                    typeName = "int";
                    break;
                case "System.String":
                    typeName = "string";
                    break;
            }
            return typeName;
        }
    }
}
