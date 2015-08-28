using System;
using System.CodeDom.Compiler;
using System.Linq;

namespace DynamicClass
{
    public class MainClass
    {
        public string Magic()
        {
            var codeToExecute = PocUtil.GetStringFromFile(PocUtil.Path);

            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");

            CompilerParameters parameters = new CompilerParameters
            {
                GenerateInMemory = true,
                GenerateExecutable = false 
            };

            CompilerResults compilerResults = provider.CompileAssemblyFromSource(parameters, codeToExecute);

            var types = compilerResults.CompiledAssembly.DefinedTypes;

            dynamic instanceFromcompilerResults = Activator.CreateInstance(types.FirstOrDefault().AsType());

            return instanceFromcompilerResults.MethodOne();
        }
    }
}