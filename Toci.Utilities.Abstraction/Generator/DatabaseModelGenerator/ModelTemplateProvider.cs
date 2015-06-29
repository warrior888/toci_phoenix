using System;
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
        public {1} {0}
            {{
                get
                {{
                     return ({1}) Fields[{0:U}].GetValue();
                }}
                set
                {{
                    SetValue({0:U}, value);
                }}
            }}
        ";

        private const string DefaultUsings =
 @"Toci.Db.DbVirtualization;
using Toci.Db.Interfaces";           
     


     
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
            return string.Format(new UpperAndLowerStringFormat(),PropertyPattern,values);
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
    }
}
