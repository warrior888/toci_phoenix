namespace Toci.Utilities.Interfaces.User.Privileges
{
    public interface IPrivilege
    {
        int Id { get; set; }

        string Name { get; set; }

        //void GrantPrivilegeToUsers(params IUser[] user);

        //void RevokePrivilegeFromUsers(params IUser[] user);

        //Dictionary<int, IUser> PrivilegedUsers { get; }

        // Dictionary<int, IPrivilege> GetParentPrivileges();

        // Dictionary<int, IPrivilege> GetChildPrivileges();

        // name, icon url ?
    }
}
