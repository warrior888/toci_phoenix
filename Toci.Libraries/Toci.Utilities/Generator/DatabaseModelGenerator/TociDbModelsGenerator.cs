using Toci.Utilities.Abstraction.Generator.DatabaseModelGenerator;
using Toci.Utilities.Interfaces.Generator.DatabaseModelGenerator;

namespace Toci.Utilities.Generator.DatabaseModelGenerator
{
    public class TociDbModelsGenerator : ModelsGenerator
    {
        public TociDbModelsGenerator(IModelGenerator modelGenerator) : base(modelGenerator)
        {
            base.ModelExtension = "cs";
            // WIem tu brakuje.....ale za ch** nie mogę sobie przypomnieć co tu miało być :/

        }
    }
}
