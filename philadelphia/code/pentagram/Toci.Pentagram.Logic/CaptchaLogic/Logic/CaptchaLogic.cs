using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Pentagram.Logic.CaptchaLogic.Abstract;

namespace Toci.Pentagram.Logic.CaptchaLogic.Logic
{
	class CaptchaLogic : CaptchaParser
	{
		public override string ConvertToBase64(string codeSnippet)
		{
			// TODO: implement
			return "";
		}

		// private methods:
		// TODO: string codeSnippet -> png
		// TODO: png -> base64
		// TODO: return it to front end
	}
}
