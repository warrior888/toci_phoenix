using System.Configuration;
using DbCredentials.Config;

namespace Toci.CredentialsApi.Models
{
    public class VazcoDbConfig: DbConfig
    {
        public VazcoDbConfig()
        {
            login = ConfigurationManager.AppSettings["login"];
            secret = ConfigurationManager.AppSettings["secret"];
            address = ConfigurationManager.AppSettings["address"];
            dataBaseName = ConfigurationManager.AppSettings["DataBaseName"];
        } 
    }
}