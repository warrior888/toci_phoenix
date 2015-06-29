using Toci.Utilities.Interfaces.Document.DocumentParse;
using Toci.Utilities.Interfaces.User;
using _3mb.Bll.Essential;
using _3mb.Bll.Interfaces.User;

namespace _3mb.Bll.User
{
    public class UserLogic : BllDbLogic, IUserLogic
    {
        private IDocumentInterpreter _docInterpreter;

        public UserLogic(
            IDocumentInterpreter docInterpreter
            //IDocumentRecognizer
            )
        {
            _docInterpreter = docInterpreter;
        }

        // db handle dla user id pobiera dane
    }
}
