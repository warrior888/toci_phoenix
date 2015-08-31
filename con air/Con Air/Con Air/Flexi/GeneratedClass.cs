using System.Collections.Generic;

namespace Con_Air.Flexi
{
    public class GeneratedClass : IGeneratedClass
    {
        public virtual string GetGeneratedClass()
        {
            return "public class GeneratedClass : IGeneratedClass { public string GetGeneratedClass() { return \"public class GeneratedClass : IGeneratedClass {}\"; } }";
        }

        public string GetGeneratedClass(string className, List<string> publicMethodsSigantures)
        {
            throw new System.NotImplementedException();
        }

        /*
         * create table jakkolwiek(
         *  ...
         * );
         */
    }
}