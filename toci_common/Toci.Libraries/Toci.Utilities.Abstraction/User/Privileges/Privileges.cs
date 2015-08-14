using Toci.Utilities.Interfaces.User.Privileges;

namespace Toci.Utilities.Abstraction.User.Privileges
{
    public abstract class Privileges : IPrivilege
    {
        /*
         * dodawanie
         * edycja
         * kasowanie
         * wysylanie korespondencji
         * nadawanie uprawnien
         * dodawanie pozycji
         * dodawanie uzytkownikow 
         * modyfikacja pozycji
         * modyfikacja uzytkownikow 
         * zmiana hasla uzytkownika
         */
        public int Id { get; set; }

        public string Name { get; set; }

        protected Privileges(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
