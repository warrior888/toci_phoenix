using System.Collections.Generic;
using Toci.Utilities.Common.Api;

namespace Toci.Utilities.Api
{
    public class ApiSimpleResultManager : ApiResultManager<string, SimpleResult>
    {
        private ApiJsonSerializer _serializer = new ApiJsonSerializer();

        public override Dictionary<string, string> GetApiResult(SimpleResult result, string serializationFormat) // parametr serializacji slownika data
        {
            var apiResult = new Dictionary<string, string>
            {
                { "code", result.Code.ToString() },
                { "message", result.Message },
                { "data", _serializer.GetJson(result.Data) },
            };

            if (result.Code > 0)
            {
                apiResult.Add("errorMsg", result.ErrorMessage);
            }

            return apiResult;
        }
    }
}