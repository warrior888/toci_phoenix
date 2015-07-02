using System;

namespace _3mb.Bll.Interfaces.Abstraction
{
    public abstract class BllException : ApplicationException
    {
        protected string CustomMessage;
        public ILogSaver Logs;
        public IExceptionNotifier Notifier;

        protected BllException(string customMessage, string internalMessage)
        {
            if (!string.IsNullOrEmpty(internalMessage) && Logs != null)
                Logs.SaveToLog(LogPriority.BLL_EXCEPTION, internalMessage);

            CustomMessage = customMessage;
        }

        public abstract void NotifyUser(string customMessage);
    }
}