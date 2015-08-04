using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mime;
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
	    private MemoryStream DrawImage(string stream)
	    {
	        MemoryStream ms;
	        Image img=new PngParser().parseImage(stream);
	        using (ms = new MemoryStream())
	        {
                img.Save(ms,ImageFormat.Png);
            }
	        return ms;
	    }

        string ConvertToBase64()


		// TODO: string codeSnippet -> png
		// TODO: png -> base64
		// TODO: return it to front end
	}
}
