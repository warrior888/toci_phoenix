using System.Drawing;

namespace Toci.Pentagram.Logic.CaptchaLogic.Abstract
{
    public abstract class ImageData<TtypeOfStream, TtypeofImage>
    {
        protected Font font;
        protected int FontSize;

        public abstract TtypeofImage parseImage(TtypeOfStream stream);


    }

}
