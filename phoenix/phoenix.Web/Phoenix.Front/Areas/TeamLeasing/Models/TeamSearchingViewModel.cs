using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Phoenix.Front.Areas.TeamLeasing.Models
{
    public class TeamSearchingViewModel
    {
        public string test = "nic się nie stało";
        public string AvailableFrom;
        public string AvailableTo;
        public List<string> Tech = new List<string>();

        public IEnumerable<SelectListItem> TechList = new List<SelectListItem>
                {
                    new SelectListItem { Text = "C#", Value = "C#"},
                    new SelectListItem { Text = "PHP", Value = "PHP"},
                    new SelectListItem { Text = "JavaScript", Value = "JavaScript"}
                };
            }
}
    
