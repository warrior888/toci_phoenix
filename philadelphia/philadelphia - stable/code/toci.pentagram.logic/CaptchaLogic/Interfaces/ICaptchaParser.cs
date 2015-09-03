using System.Drawing;

namespace Toci.Pentagram.Logic.CaptchaLogic.Interfaces
{
    public interface ICaptchaParser<TtypeOfStream>
    {   
        Image ParseImage(TtypeOfStream stream);
    }
}
