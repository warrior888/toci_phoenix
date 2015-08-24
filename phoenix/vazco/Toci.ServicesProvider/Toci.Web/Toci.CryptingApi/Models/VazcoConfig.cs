using System.Configuration;
using DbCrypting.Config;

namespace Toci.CryptingApi.Models
{
    public class VazcoConfig: DbConfig
    {
        public VazcoConfig()
        {
            login = ConfigurationManager.AppSettings["login"];
            secret = ConfigurationManager.AppSettings["secret"];
            address = ConfigurationManager.AppSettings["address"];
            DataBaseName = ConfigurationManager.AppSettings["DataBaseName"];

           

        }
    }
}