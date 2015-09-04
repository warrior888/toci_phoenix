using System;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Toci.Utilities.Test.Developers.Warrior.Poc
{
    [TestClass]
    public class GeneralTests
    {
        [TestMethod]
        public void TestHttpCommunication()
        {
            HttpClient client = new HttpClient();
            //WebRequest request = new HttpWebRequest();

            var result = client.GetStreamAsync(new Uri("", UriKind.Absolute));

            result.Wait();

            var resStream = result.Result;

            //resStream.Read()

        }
    }
}
