using toci.pentagram.interfaces;

namespace toci.pentagram.bll.Buisnessmodel
{
    public class ApplicationTestsBuisnessModel:IApplicationTestsBuisnessModel
    {
        public int Id { get; set; }
        public string Codesnipet { get; set; }

        public string Rightanswers { get; set; }
    }
}