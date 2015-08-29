using System.IO;

namespace DynamicClass
{
    public static class PocUtil
    {
        public static string Path = @"..\..\..\DynamicClass\class.txt";

        public static string GetStringFromFile(string path)
        {
            string content = string.Empty;

            if (File.Exists(path))
            {
                content = File.ReadAllText(path);
            }

            return content;
        }
    }
}