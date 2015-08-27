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
using Toci.Pentagram.Logic.CaptchaLogic.Interfaces;

namespace Toci.Pentagram.Logic.CaptchaLogic.Logic
{
	public class CaptchaLogic : CaptchaParser
	{

	    private ICaptchaParser<string>_builder;
        public CaptchaLogic(ICaptchaParser<string> builder)
        {
            _builder = builder;
        }

		public override string ConvertToBase64(string codeSnippet)
		{
		    return ConvertfromMs(DrawImage(codeSnippet));
		    // TODO: implement
		    //return "";
		}


		// private methods:
	   public  MemoryStream DrawImage(string stream)
	    {
	        MemoryStream ms;
	        Image img=_builder.ParseImage(stream);
	        using (ms = new MemoryStream())
	        {
                img.Save(ms,ImageFormat.Png);
            }
	        return ms;
	    }

	    private string ConvertfromMs(MemoryStream stream)
	    {
	      //  byte[] imageByte = stream.ToArray();
	        return Convert.ToBase64String(stream.ToArray());
	    }


		// TODO: string codeSnippet -> png
		// TODO: png -> base64
		// TODO: return it to front end
	}

    
}
