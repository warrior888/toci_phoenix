using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.GeneratedModels
{
    public class portfolio_skills_technologies : Model
    {
        public portfolio_skills_technologies() : base("portfolio_skills_technologies")
        {
        }
         
         
        public const string FK_ID_PORTFOLIO = "fk_id_portfolio";
        public int FkIdPortfolio
            {
                get
                {
                     return GetValue<int>(FK_ID_PORTFOLIO);
                }
                set
                {
                    SetValue(FK_ID_PORTFOLIO, value);
                }
            }
         
        public const string FK_ID_SKILLS_TECHNOLOGIES = "fk_id_skills_technologies";
        public int FkIdSkillsTechnologies
            {
                get
                {
                     return GetValue<int>(FK_ID_SKILLS_TECHNOLOGIES);
                }
                set
                {
                    SetValue(FK_ID_SKILLS_TECHNOLOGIES, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new portfolio_skills_technologies();
        }
    }
}
