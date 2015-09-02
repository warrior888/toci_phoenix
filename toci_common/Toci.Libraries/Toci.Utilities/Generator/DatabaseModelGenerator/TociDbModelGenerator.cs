using Toci.Utilities.Abstraction.Generator.DatabaseModelGenerator;
using Toci.Utilities.Interfaces.Generator.DatabaseModelGenerator;
using Toci.Utilities.Interfaces.Generator.DatabaseModelGenerator.DbDdlParser;

namespace Toci.Utilities.Generator.DatabaseModelGenerator
{
    public class TociDbModelGenerator : ModelGenerator
    {
        public TociDbModelGenerator(IDdlParser ddlParser, IModelTemplateProvider templateProvider) : base(ddlParser, templateProvider)
        {
           // TemplateProvider.Usings = "";
            // templates etc
        }

        //  Jak coś zmieniłem zwracany typ poniższej metody z stringBuildera na string. - by Robson
        
    }
}
