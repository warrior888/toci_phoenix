using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace IdServ.Configruation
{
    internal static class Cert
    {//TODO Tu bedzie pobieralo certa z dysku potrzebnego do szyfrowania tokenow etc
        public static X509Certificate2 Load()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream(
            "IdServ.Configruation.Cert.idsrv3test.pfx"))
            {
                return new X509Certificate2(ReadStream(stream), "idsrv3test");
            }
        }
        private static byte[] ReadStream(Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (var ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}