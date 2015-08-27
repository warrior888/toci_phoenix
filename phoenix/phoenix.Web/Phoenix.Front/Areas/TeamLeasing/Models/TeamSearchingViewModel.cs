using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phoenix.Bll.BusinessModels.DevelopersList;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;
using Phoenix.Bll.Interfaces.BusinessModels.TeamLeasing;
using Phoenix.Bll.Interfaces.Logic.DevelopersList;
using Phoenix.Bll.Logic.DevelopersList;

namespace Phoenix.Front.Areas.TeamLeasing.Models
{
    public class TeamSearchingViewModel
    {
        private SkillLogic _skillLogic = new SkillLogic();

        //TODO: DI

        public TeamSearchingViewModel()
        {
            var skillsCollection = _skillLogic.GetAllSkills().ToList();
            TechList = PopulateTechList(skillsCollection);
        }

        public string test { get; set; }

        public TeamLeasingOffer LeasingOffer { get; set; }
        public string AvailableFrom { get; set; }
        public string AvailableTo { get; set; }
        public int CountOfTeam { get; set; }
        public float StartWorkHour { get; set; }
        public float EndWorkHour { get; set; }
        public DeveloperSkillBusinessModel SkillSet { get; set; }

        public List<string> Tech { get; set; }

        public IEnumerable<SelectListItem> TechList;
       
       


        //TODO: generic method (abstract TociViewModel?)

        private IEnumerable<SelectListItem> PopulateTechList(List<ISkillBusinessModel> list)
        {
            var returnList = new List<SelectListItem>();
            list.ForEach(i =>{
                returnList.Add(new SelectListItem
                {
                    Text = i.SkillName,
                    Value = i.SkillName
                });
            });

            return returnList;
        } 
    }
}
    
