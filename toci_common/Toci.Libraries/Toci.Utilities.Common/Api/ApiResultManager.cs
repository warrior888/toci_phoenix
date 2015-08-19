using System.Collections.Generic;

namespace Toci.Utilities.Common.Api
{
    public abstract class ApiResultManager<TInner, TResult>
    {
        public abstract Dictionary<string, TInner> GetApiResult(TResult result, string serializationFormat);
    }
}