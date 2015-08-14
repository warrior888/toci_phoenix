namespace Toci.Utilities.Common.String
{
    public static class PathUtilities
    {
        private const string ExtensionDelimiter = ".";

        public static string GetExtension(string path)
        {
            //todo using a delimiter instead strongly typed 3 last chars
            return path.Substring(path.Length - 3, 3);
        }
    }
}
