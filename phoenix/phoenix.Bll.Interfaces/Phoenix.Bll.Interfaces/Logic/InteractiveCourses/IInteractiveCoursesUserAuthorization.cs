namespace Phoenix.Bll.Interfaces.Logic.InteractiveCourses
{
    public interface IInteractiveCoursesUserAuthorization
    {
        bool CheckUserAccountBalance(int userId); //uzycie DAL sprawdzenie w bazie stanu konta usera 
        //ewentualnie 2 parametr min wartosc jaka user musi miec na koncie 
    }
}