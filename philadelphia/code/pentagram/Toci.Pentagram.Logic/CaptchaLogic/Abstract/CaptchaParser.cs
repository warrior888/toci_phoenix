using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Pentagram.Logic.CaptchaLogic.Abstract
{
	abstract class CaptchaParser
	{
		public abstract string ConvertToBase64(string codeSnippet);

		// private methods:
		// TODO: string codeSnippet -> png
		// TODO: png -> base64
		// TODO: return it to front end

		// jak się oznacza klasy abstrakcyjne? CaptchaParserAbstract? xD
	}
}
