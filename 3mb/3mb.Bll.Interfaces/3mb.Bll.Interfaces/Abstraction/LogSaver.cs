namespace _3mb.Bll.Interfaces.Abstraction
{
    public abstract class LogSaver : ILogSaver
    {
        public abstract void SaveToLog(LogPriority priority, string internalMessage);
    }
}
