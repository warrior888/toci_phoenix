using System;
using System.Collections.Generic;

namespace Toci.Utilities.Common.Exceptions
{
    public abstract class TociApplicationException : ApplicationException
    {
        protected string UiMessage;

        protected int ErrorCode;

        protected TociApplicationException(string uiMessage, string errMessage, int errorCode,
            TociApplicationException innerException = null)
            : base(errMessage, innerException)
        {
            UiMessage = uiMessage;
            ErrorCode = errorCode;
        }

        public abstract List<string> GetErrorList(TociApplicationException ex);

        public abstract int GetErrorCode(TociApplicationException ex);

        protected virtual string GetErrMsg(TociApplicationException ex)
        {
            return ex.UiMessage;
        }

        protected virtual int GetErrCode(TociApplicationException ex)
        {
            return ex.ErrorCode;
        }
    }
}