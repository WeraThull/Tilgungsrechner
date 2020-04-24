using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    abstract class Darlehen
    {
        public double KreditBetrag { get; set; }
        public double Zinssatz { get; set; }
        public int Beginn { get; set; }

        public abstract OutputData[] BerechneDarlehen(); // bleibt leer
    }
    class Annuitaet : Darlehen
    {
        public InputData Input;
        public Annuitaet(InputData input)
        {
            Input = input;
            Input.getInput();
            KreditBetrag = Input.KreditBetrag;
            Zinssatz = Input.Zinssatz;
            startTilgungssatz = Input.Tilgungssatz;
        }
        public double startTilgungssatz { get; set; }
        public int yearAnnu { get; set; }
        public int monAnnu { get; set; }


        
        /// <summary>
        /// Hier erfolgt die Berechnung
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override OutputData[] BerechneDarlehen()
        {
            
            OutputData[] data = new OutputData[Input.Laufzeit];

            // Berechnung Jahr 1  --------------------------------------------------------> muss monatlich erfolgen
            OutputData dataYear1 = new OutputData(); // dies ist ein Test ... oder auch nicht.
            dataYear1.Kreditbetrag = KreditBetrag;
            dataYear1.Zinsen = KreditBetrag * Zinssatz/100;
            dataYear1.Tilgung = KreditBetrag * startTilgungssatz/100;
            dataYear1.Annuitaet = dataYear1.Tilgung + dataYear1.Zinsen;
            dataYear1.Restbetrag = dataYear1.Kreditbetrag - dataYear1.Tilgung;
            dataYear1.Date = Input.Date;

            data[0] = dataYear1;
            // Berechnung Jahr 2-n -------------------------------------------------------> erfolgt jährlich
            double lastRestBetrag = dataYear1.Restbetrag;
            for (int i = 2; i <= Input.Laufzeit; i++)
            {
                OutputData dataYearN = new OutputData();
                dataYearN.Kreditbetrag = lastRestBetrag;
                dataYearN.Zinsen = dataYearN.Kreditbetrag * Zinssatz;
                dataYearN.Tilgung = dataYear1.Annuitaet - dataYearN.Zinsen;
                dataYearN.Annuitaet = dataYear1.Annuitaet;
                dataYearN.Restbetrag = dataYearN.Kreditbetrag - dataYearN.Tilgung;
                dataYearN.Date = Input.Date.AddYears(i - 1);

                lastRestBetrag = dataYearN.Restbetrag;

                data[i - 1] = dataYearN;
            }

            return data;
        }
    }
    //class Tilgung : Darlehen
    //{
    //    public int monTilgung { get; set; }
    //    public int jahrTilgung { get; set; }
    //    public double konstTilgungsatz { get; set; }

    //    public override OutputData[] BerechneDarlehen()
    //    {
    //        // Hier könnte Ihre Werbung stehen
    //    }
    //}
}
