using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Toci.CarLot.Dal.Zwyciestwo.Auta
{
    class Porsze : CarBase
    {
        protected override int KindOfGasoline()
        {
            throw new NotImplementedException();
        }

        

        protected double pow(double podstawa, int wykladnik)
        {
            const double mnoznik = podstawa;
            while(wykladnik--) podstawa *= mnoznik;
            return podstawa;

            // dobra robota, wygrałeś piernika! :DD
        }
        public void NicNiePotrafie()
        {
            Console.WriteLine("Ale może się nauczę");
            Console.WriteLine("Ale może się nauczę");
        }
        protected void wtf()
        {
            while (1)
            {
                throw new Exception("wow");
            }
        }
    }
}
