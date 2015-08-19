using System.Collections.Generic;
using Toci.Utilities.Common.Api;

namespace Toci.Utilities.Api
{
    public class ApiSimpleResultManager : ApiResultManager<object, SimpleResult>
    {
        private ApiJsonSerializer _serializer = new ApiJsonSerializer();

        public override Dictionary<string, object> GetApiResult(SimpleResult result, string serializationFormat) // parametr serializacji slownika data
        {
            var apiResult = new Dictionary<string, object>
            {
                { "code", result.Code.ToString() },
                { "message", result.Message },
                
            };
            if (result.Data != null)
            {
                apiResult.Add("data", result.Data);
            }
            if (result.Code > 0)
            {
                apiResult.Add("errorMsg", result.ErrorMessage);
            }

            return apiResult;
        }
    }
}