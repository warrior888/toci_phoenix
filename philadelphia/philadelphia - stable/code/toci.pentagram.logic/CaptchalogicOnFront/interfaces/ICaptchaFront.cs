namespace toci.pentagram.logic.CaptchalogicOnFront.interfaces
{
    public interface ICaptchaFront
    {
        string GetAndShowRandQuestion();
        bool Compare(string answer);
        
    }
}