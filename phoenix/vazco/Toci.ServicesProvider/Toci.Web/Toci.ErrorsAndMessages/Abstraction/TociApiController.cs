using System.Web.Http;
using Toci.Utilities.Api;
using Toci.Utilities.Common.Api;

namespace Toci.ErrorsAndMessages.Abstraction
{
    public abstract class TociApiController : ApiController
    {
        protected ApiResultManager<string, SimpleResult> ResultManager;

        protected TociApiController()
        {
            ResultManager = new ApiSimpleResultManager();
        }
    }
}