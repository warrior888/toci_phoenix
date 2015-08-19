using System.Collections.Generic;

namespace Toci.Utilities.Common.Internationalization
{
    public abstract class TranslationsManager // enable TPL ?  extends basic TPL generic functionality + delegates
    {
        //protected TranslationsManager(int language)

        protected Dictionary<string, string> Translations;

        //.resx

        public abstract string GetTranslation(string code); // dict Translations 

        public abstract Dictionary<string, string> GetTranslation(List<string> codes);
    }
}