using System.Collections.Generic;

namespace Con_Air.Flexi
{
    public interface IGeneratedClass
    {
        /*
         class UltraFlexible
         * {
         * public void Dupa()
         * {
         * 
         * }
         * }
         */

        string GetGeneratedClass();
        string GetGeneratedClass(string className, List<string> publicMethodsSigantures); //??
    }
}