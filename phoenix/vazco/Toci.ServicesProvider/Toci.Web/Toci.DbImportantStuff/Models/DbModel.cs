using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBAccessResourceServer.Models
{
    public class DbModel
    {
        [Required]
        public string nick { get; set; }
        public DateTime addingTime { get; set; }
        [Required]
        public string data { get; set; }
    }
}