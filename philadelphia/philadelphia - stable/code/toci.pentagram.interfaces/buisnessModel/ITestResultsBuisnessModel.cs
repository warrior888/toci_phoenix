
namespace toci.pentagram.interfaces
{
    public interface ITestResultsBuisnessModel
    {
        IApplicationTestsBuisnessModel applicationtests { get; set; }
        string IdUser { get; set; }
        string Result { get; set; }
    }
}
