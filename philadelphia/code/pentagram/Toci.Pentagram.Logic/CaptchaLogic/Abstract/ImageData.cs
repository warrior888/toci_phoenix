using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Pentagram.Logic.CaptchaLogic.Abstract
{
    public abstract class ImageData<TtypeOfStream, TtypeofImage>
    {
        protected Font font;
        protected int FontSize;

        public abstract TtypeofImage parseImage(TtypeOfStream stream);


    }

}
