using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Pentagram.Logic.CaptchaLogic.Interfaces
{
    public interface ICaptchaParser<TtypeOfStream, TtypeofImage>
    {   
        TtypeofImage ParseImage(TtypeOfStream stream);
    }
}
