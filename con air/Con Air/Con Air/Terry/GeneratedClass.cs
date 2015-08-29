using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;

namespace Con_Air.Terry
{
    public class GeneratedClass
    {
        public string GetGeneratedClass()
        {
            return "public class TestClass { private string msg = \"Hejka\"" +
                   " public string GetMsg() {return msg}" +
                   "}";
        }


        public void Compile(string body)
        {

            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters cp = new CompilerParameters();
            
            cp.ReferencedAssemblies.Add("System.dll");
            cp.GenerateExecutable = false;
            cp.GenerateInMemory = true;
            

            CompilerResults cr = provider.CompileAssemblyFromFile(cp, GetGeneratedClass());

        }

    }
}