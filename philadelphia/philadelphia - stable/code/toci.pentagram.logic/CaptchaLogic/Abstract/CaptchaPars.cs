using System.Drawing;
using Toci.Pentagram.Logic.CaptchaLogic.Interfaces;

namespace Toci.Pentagram.Logic.CaptchaLogic.Abstract
{
  public abstract  class CaptchaPars: ICaptchaBuilder
  {
  
      protected int FontSize;
    //  public abstract Image ParseImage(string stream);
      protected int widthOfTab;
      public Color color { get; set; }
      public  Brush brush { get; set; }
      public  Font Font { get; set; }
      protected char[] separators;

     public  CaptchaPars()
      {
          FontSize = 18;
          Font = new Font("Arial", FontSize);
         separators = new[] { '\n' };
         color = Color.AliceBlue;
          brush = Brushes.Black;
         widthOfTab = 4; 
      }
    }
}
