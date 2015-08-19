using System;
using System.Collections.Generic;
using System.Linq;

namespace Toci.Utilities.Api
{
    public class ApiJsonSerializer
    {
        //private const string _pattern = "{0}";
        private const string _patternElement = "\"{0}\": {1}";
        private const string _delimiter = ",";
        public virtual string GetJson(Dictionary<string, string> elements)
        {
            
            var entries = elements.Select(item => string.Format(_patternElement, elements.Keys, elements.Values));

            return "{" + string.Join(_delimiter, entries) + "}";
        }
    }
}