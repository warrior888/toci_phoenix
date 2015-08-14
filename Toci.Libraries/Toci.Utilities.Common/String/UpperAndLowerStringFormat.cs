using System;

namespace Toci.Utilities.Common.String
{
    public class UpperAndLowerStringFormat : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;

        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            string result = arg.ToString();

            if (format == null) return result;
            switch (format.ToUpper())
            {
                case "U": return result.ToUpper();
                case "L": return result.ToLower();
             
                default: return result;
            }
        }
    }
}