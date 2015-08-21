namespace Toci.Utilities.Common.Internationalization
{
    public abstract class Translator
    {
        protected TranslationsManager TranslationsManager;
        public abstract string Translate(string code, int language); // use TranslationsManager ?
    }
}