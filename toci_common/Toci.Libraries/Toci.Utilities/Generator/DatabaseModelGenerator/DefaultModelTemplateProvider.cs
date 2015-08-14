using Toci.Utilities.Abstraction.Generator.DatabaseModelGenerator;

namespace Toci.Utilities.Generator.DatabaseModelGenerator
{
    public class DefaultModelTemplateProvider : ModelTemplateProvider
    {

        private const string DefaultClassModifier = "public";

        public DefaultModelTemplateProvider(string classModifiers = DefaultClassModifier)
            : base(classModifiers)
        {

        }
    }
}
