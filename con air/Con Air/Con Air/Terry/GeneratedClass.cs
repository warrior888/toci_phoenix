using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Linq;
using Microsoft.CSharp;

namespace Con_Air.Terry
{
    public class GeneratedClass
    {
        public string GetGeneratedClass()
        {
            return "public class TestClass {  public int GetValue() {return 888;}}";
                  
        }


        public int Compile()
        {

            var code = GetGeneratedClass();

            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters cp = new CompilerParameters();
            
            cp.ReferencedAssemblies.Add("System.dll");
            cp.GenerateExecutable = false;
            cp.GenerateInMemory = true;


            CompilerResults cr = provider.CompileAssemblyFromSource(cp, code);
            var typ = cr.CompiledAssembly.DefinedTypes;
            dynamic instance = Activator.CreateInstance(typ.FirstOrDefault().AsType());

            return instance.GetValue();
        }

    }
}