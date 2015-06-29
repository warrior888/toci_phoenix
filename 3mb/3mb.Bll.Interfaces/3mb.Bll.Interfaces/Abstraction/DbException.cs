using System.Data.Common;


namespace _3mb.Bll.Interfaces.Abstraction
{
    public abstract class DbException : BllException
    {
        protected DbException(string customMessage, string internalMessage) : base(customMessage, internalMessage)
        {
        }
    }
}
