using System.Web.Http;
using Toci.Utilities.Api;
using Toci.Utilities.Common.Api;

namespace Toci.DigitalSignatureApi.Abstraction
{
    public abstract class TmpDsTociApiController : ApiController
    {
        protected ApiResultManager<object, SimpleResult> ResultManager;

        protected TmpDsTociApiController()
        {
            ResultManager = new ApiSimpleResultManager();
        }
    }
}