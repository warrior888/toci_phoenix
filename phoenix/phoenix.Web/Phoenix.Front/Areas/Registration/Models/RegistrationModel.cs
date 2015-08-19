using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Phoenix.Front.Areas.Registration.Models
{
    public class RegistrationModel
    {
        [Required]
        public string login { get; set; }
        // [StringLength(32)]
        [Required, StringLength(32)]
        public string password { get; set; }

        [Required, EmailAddress(ErrorMessage = "Email jest niepoprawny!")]
        public string email { get; set; }
        [Required]
        public string nick { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string surname { get; set; }
    }
}