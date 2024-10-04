using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftDrinksGUI
{
    internal class Drinks
    {
        public string Nev { get; set; }
        public string EdesitoAnyag { get; set; }
        public int Ar { get; set; }
        public string CsomagolasTipusa { get; set; }
        public int GyumolcsTartalom { get; set; }
        public int CsomagolasEgysege { get; set; }

        public Drinks(string sor)
        {
            var s = sor.Split(";");
            Nev = s[0];
            EdesitoAnyag = s[1];
            Ar = int.Parse(s[2]);
            CsomagolasTipusa = s[3];
            GyumolcsTartalom = int.Parse(s[4]);
            CsomagolasEgysege = int.Parse(s[5]);
        }
    }
}
