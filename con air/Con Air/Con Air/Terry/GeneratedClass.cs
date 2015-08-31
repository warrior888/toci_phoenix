using System;
using System.CodeDom.Compiler;
using System.Linq;
using Con_Air.Flexi;
using Microsoft.CSharp;


namespace Con_Air.Terry
{
    public class TerryGeneratedClass : GeneratedClass
    {
        public string GetGeneratedClass(int counter)
        {
            return "public class TestClass {  public int GetValue() {return " + counter + ";} public string GetMsg() {return \"Toci\";}}";
                  
        }

        public void Compile(out int liczba, out string napis)
        {

            var code = GetGeneratedClass();

            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters cp = new CompilerParameters();
            
            cp.ReferencedAssemblies.Add("System.dll");
            cp.GenerateExecutable = false;
            cp.GenerateInMemory = true;
            
            CompilerResults cr = provider.CompileAssemblyFromSource(cp, code);
            var type = cr.CompiledAssembly.DefinedTypes;
            dynamic instance = Activator.CreateInstance(type.FirstOrDefault().AsType());

            liczba =  instance.GetValue();
            napis = instance.GetMsg();

        }

    }
}