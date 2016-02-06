namespace Toci.Utilities.Interfaces.Generator.DatabaseModelGenerator
{
    public interface IModelTemplateProvider
    {
        string GetFilledPropertyTemplate(params string[] values);

        string Usings { get; set; } 
        string NamespaceName { get; set; } 
        string Parents { get; set; }
        string ClassName { get; set; }
        string ClassModifiers { get; set; }
        string BaseConstructorArguments { get; set; }

        string GetClass(string contents);
        /*
         * create
         * id serial primary key
        */

        // GetFilledTemplate("id", "int")
//    {
        //        string.Format(pattern, );
//    }


        /*
        
       string pattern =  "
         public const string {2} = "{1}";
         
         public {0} {}
        {
            get
            {
                return ({0}) Fields[{2}].GetValue();
            }
            set
            {
                SetValue({2}, value);
            }
        }";
         */
    }
}
