using Toci.Utilities.Common.Internationalization;

namespace Toci.ErrorsAndMessages.Managers
{
    public class BlindTranslator : Translator
    {
        public override string Translate(string code, int language)
        {
            return code;
        }
    }
}