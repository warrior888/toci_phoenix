using System.Collections.Generic;

namespace Toci.Pentagram.Logic.Models
{
    public class RegistrationTask
    {
        public string Captcha { get; set; }
        public List<string> Questions { get; set; }
        public string Id { get; set; }
        public List<string> Inputs { get; set; }
    }
}