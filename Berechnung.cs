//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Calc
//{
//    public static class Berechnung
//    { //Mehrere Methoden mit dem gleichen Namen ergeben eine Überladung
//        public static double Addition(double z1, double z2)
//        {
//            double summe = z1 + z2;
//            return summe;
//        }
//        public static int Addition(int z1, int z2)
//        {
//            int summe = z1 + z2;
//            return summe;
//        }
//        public static int Addition(int z1, int z2, int z3)
//        {
//            int summe = z1 + z2 + z3;
//            return summe;
//        }
//        public static int Addition(Data d)
//        {
//            int summe = d.z1 + d.z2;
//            return summe;
//        }
//    }
//    public class Data
//    {
//        public int Z1 { get; set; }
//        public int z2 { get; set; }
//        public int Z87 { get; set; }

//        public Data(int z1, int z2)
//        {
//            // this verweist darauf, dass ich eine Eigenschaft dieser Klasse verweise. Durch Groß-Kleinschreibung wird das this hier übeflüssig
//            Z1 = z1; 
//            this.z2 = z2;
//        }
//    }
//}
