using _3mb.Bll.Interfaces.Abstraction;

namespace _3mb.Bll.Interfaces
{
    public interface ILogSaver
    {
        void SaveToLog(LogPriority priority, string internalMessage);
    }
}
