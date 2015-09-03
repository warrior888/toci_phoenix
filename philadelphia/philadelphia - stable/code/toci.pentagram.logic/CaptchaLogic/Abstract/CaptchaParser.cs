namespace Toci.Pentagram.Logic.CaptchaLogic.Abstract
{
    public abstract class CaptchaParser
	{
		public abstract string ConvertToBase64(string codeSnippet);

		// private methods:
		// TODO: string codeSnippet -> png
		// TODO: png -> base64
		// TODO: return it to front end

		// jak się oznacza klasy abstrakcyjne? CaptchaParserAbstract? xD
	}
}
