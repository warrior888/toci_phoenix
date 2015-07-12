using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Bll.Interfaces.Logic.CoursesList
{
    public interface ISessionsLogic
    {                
        bool EditSessionName(string sessionName);
        bool EditSessionCount(int sessionCount);
        bool EditStartSession(DateTime startSession);
        bool EditEndSession(DateTime sndSession);


        string GetSessionName(ISessionsLogic session);                                                                 
        double GetSessionCount(ISessionsLogic session);
        DateTime GetStartSession(ISessionsLogic session);
        DateTime GetEndSession(ISessionsLogic session);


        bool CalculateSessionCount(ISessionsLogic session);     //dałbym prywatną w klasie bazowej?

    }
}
