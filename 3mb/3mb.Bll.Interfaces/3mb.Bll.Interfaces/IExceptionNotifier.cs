using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3mb.Bll.Interfaces
{
    public interface IExceptionNotifier
    {
        void NotifyUser(string customMessage);
    }
}
