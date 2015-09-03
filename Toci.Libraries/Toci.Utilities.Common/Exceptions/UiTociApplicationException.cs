using System.Collections.Generic;
using Toci.Utilities.Common.Internationalization;

namespace Toci.Utilities.Common.Exceptions
{
    public abstract class UiTociApplicationException : TociApplicationException
    {
        public Translator Translator { get; set; }
        public LanguageManager LanguageManager { get; set; }

        private List<string> _resultErrorList = new List<string>();

        private int _errCode;

        protected UiTociApplicationException(string uiMessage, string errMessage, int errorCode, TociApplicationException innerException = null)
            : base(uiMessage, errMessage, errorCode, innerException)
        {
            
        }

        public override List<string> GetErrorList(TociApplicationException ex)
        {
            _resultErrorList.Add(Translator.Translate(GetErrMsg(ex), LanguageManager.GetLAnguage()));

            if (ex.InnerException as TociApplicationException != null)
            {
                GetErrorList(ex.InnerException as TociApplicationException);
            }

            return _resultErrorList;
        }

        public override int GetErrorCode(TociApplicationException ex)
        {
            _errCode = _errCode | base.GetErrCode(ex);

            if (ex.InnerException as TociApplicationException != null)
            {
                GetErrorCode(ex.InnerException as TociApplicationException);
            }

            return _errCode;
        }
    }
}