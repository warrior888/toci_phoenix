using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Pentagram.Logic.CaptchaLogic.Interfaces
{
    public interface ICaptchaParser<TtypeOfStream>
    {   
        Image ParseImage(TtypeOfStream stream);
    }
}
