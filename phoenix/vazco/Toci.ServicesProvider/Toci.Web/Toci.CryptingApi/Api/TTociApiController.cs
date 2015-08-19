using System.Web.Http;
using Toci.Utilities.Api;
using Toci.Utilities.Common.Api;

namespace Toci.CryptingApi.Api
{
    public abstract class TTociApiController : ApiController
    {
        protected ApiResultManager<object, SimpleResult> ResultManager;

        protected TTociApiController()
        {
            ResultManager = new ApiSimpleResultManager();
        }
    }
}