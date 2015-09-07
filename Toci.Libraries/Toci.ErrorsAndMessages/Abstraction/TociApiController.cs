using System.Web.Http;
using Toci.Utilities.Api;
using Toci.Utilities.Common.Api;

namespace ErrorsAndMessages.Abstraction
{
    public abstract class TociApiController : ApiController
    {
        protected ApiResultManager<object, SimpleResult> ResultManager;

        protected TociApiController()
        {
            ResultManager = new ApiSimpleResultManager();
        }
    }
}