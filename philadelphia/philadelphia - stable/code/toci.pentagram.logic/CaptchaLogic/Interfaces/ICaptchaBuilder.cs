using System.Drawing;

namespace Toci.Pentagram.Logic.CaptchaLogic.Interfaces
{
    public interface ICaptchaBuilder
   {
      // char[] separators { get; set; }
       //= new[] {'\n'};
       Color color { get; set; }// = Color.AliceBlue;
       Brush brush { get; set; }// = Brushes.Black;
       Font Font { get; set; }
        //TtypeofImage ParseImage(TtypeOfStream stream);
        // protected Font font { get; set; }
        // protected int FontSize { get; set; }


    }
}
