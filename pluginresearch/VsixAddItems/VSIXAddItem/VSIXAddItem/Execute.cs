using System;
using Extensibility;
using EnvDTE;
using EnvDTE80;


namespace MyAddIn
{
    public class Execute
    {
        public Connect _connect = new Connect();
        public Array _array;
        void Test()
        {
            DTE2 application= null;
            AddIn addInInst=null;
       
            ext_ConnectMode connectMode = new ext_ConnectMode();
           


            _connect.OnConnection(application, connectMode, addInInst, ref _array);




        }
        
    }
}