using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3mb.Bll.Interfaces.Abstraction
{
    public abstract class ExceptionNotifier : IExceptionNotifier
    {
        public abstract void NotifyUser(string customMessage);
    }
}
