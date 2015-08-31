using System;
using System.Text;

namespace Con_Air.Terry
{
    public static class Base64Operations
    {
        public static byte[] GetBytesFromBase64(string base64String)
        {
            return Convert.FromBase64String(base64String);
        }

        public static string GetBase64FromByteArr(byte[] byteArr)
        {
            return Convert.ToBase64String(byteArr);
        }
        public static string Decode(string encodedString)
        {
            var byteArr = Convert.FromBase64String(encodedString);
            string decodedString = Encoding.UTF8.GetString(byteArr);

            return decodedString;
        } 
        
        public static string Encode(string plainString)
        {
            var byteArr = Encoding.UTF8.GetBytes(plainString);
            string encodedString = Convert.ToBase64String(byteArr);

            return encodedString;
        }
    }
}