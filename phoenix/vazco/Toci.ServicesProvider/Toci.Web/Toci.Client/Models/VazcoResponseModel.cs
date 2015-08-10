using System.ComponentModel.DataAnnotations;

namespace Toci.Client.Models
{
    public class VazcoResponseModel
    {
        public string token_type { get; set; }
        public string access_token { get; set; }
        public string expires_in { get; set; }
        public string id { get; set; }
        public string email { get; set; }

        public string password { get; set; }
    }
}