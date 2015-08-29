using System;
using System.Reflection;

namespace Con_Air.Patryk
{
    public class PatrykLoadClass
    {
        public object Load(string dllPath, string className)
        {
            Assembly assembly = Assembly.Load(dllPath);

            //var assembly = Assembly.LoadFrom(dllPath); //??

            Type MyLoadClass = assembly.GetType(string.Format("{0}.{1}", dllPath, className));
            return Activator.CreateInstance(MyLoadClass);

            //return Activator.CreateInstance(Type.GetType("DALL.LoadClass, DALL", true));
        }
    }
}