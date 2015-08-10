using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.PatrykGeneratedModels
{
    public class portfolio_skills_technologie : Model
    {
        public portfolio_skills_technologie() : base("portfolio_skills_technologie")
        {
        }
         
        public const string ID = "id";
        public System.Int32 id
            {
                get
                {
                     return (System.Int32) Fields[ID].GetValue();
                }
                set
                {
                    SetValue(ID, value);
                }
            }
         
        public const string FK_ID_PORTFOLIO = "fk_id_portfolio";
        public System.Int32 fk_id_portfolio
            {
                get
                {
                     return (System.Int32) Fields[FK_ID_PORTFOLIO].GetValue();
                }
                set
                {
                    SetValue(FK_ID_PORTFOLIO, value);
                }
            }
         
        public const string FK_ID_SKILLS_TECHNOLOGIES = "fk_id_skills_technologies";
        public System.Int32 fk_id_skills_technologies
            {
                get
                {
                     return (System.Int32) Fields[FK_ID_SKILLS_TECHNOLOGIES].GetValue();
                }
                set
                {
                    SetValue(FK_ID_SKILLS_TECHNOLOGIES, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new portfolio_skills_technologie();
        }
    }
}
