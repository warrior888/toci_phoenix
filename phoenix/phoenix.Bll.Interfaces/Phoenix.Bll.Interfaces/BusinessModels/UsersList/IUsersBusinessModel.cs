namespace Phoenix.Bll.Interfaces.BusinessModels.UsersList
{
    public interface IUsersBusinessModel
    {
        string Nick { get; set; }

        string Name { get; set; }

        string Surname { get; set; }

        decimal AccountBalance { get; set; }
    }
}