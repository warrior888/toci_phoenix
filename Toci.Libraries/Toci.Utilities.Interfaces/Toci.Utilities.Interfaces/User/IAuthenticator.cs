namespace Toci.Utilities.Interfaces.User
{
    public interface IAuthenticator
    {
        bool Authenticate(string username, string password);
    }
}
