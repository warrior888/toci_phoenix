using System.Collections.Generic;

namespace Toci.Pentagram.Logic.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public List<RegistrationTask> RegistrationTasks { get; set; }
    }
}