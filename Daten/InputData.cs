using System;
using System.Windows.Forms;

namespace Calc.Daten
{
    public class InputData
    {
        public MyForm Form1; // DEFINITION der Variablen Form1
        public InputData(MyForm form)
        {
            this.Form1 = form; //this ist immer ein Bezug auf die Klasse // DEKLARATION der Variablen Form1
        }
        public double KreditBetrag { get; set; }
        public double Zinssatz { get; set; }
        public double Tilgungssatz { get; set; }
        public int Laufzeit { get; set; }
        public DateTime Date { get; set; }

        /// <summary>
        /// Prüfung des Wertebereichs
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public bool CheckData()
        {
            if ((CheckValue(1000, 1000000, KreditBetrag, "Kreditbetrag")) &&
               (CheckValue(1, 10, Zinssatz, "Zinssatz")) &&
               (CheckValue(1, 10, Tilgungssatz, "Tilgungssatz")) &&
               (CheckValue(1, 20, Laufzeit, "Laufzeit")))
            {
                return true;
            }
            else
                return false;
        }

        private bool CheckValue(double minValue, double maxValue, double value, string message)
        {
            // Prüfung Wertbereich
            if ((value < minValue) || (value > maxValue))
            {
                MessageBox.Show(message + " muss zwischen " + minValue.ToString() + " und " + maxValue.ToString() + " liegen");
                return false;
            }
            else
                return true;
        }
        /// <summary>
        /// Es werden die Daten aus dem Formular entgegengenommen
        /// </summary>
        /// <returns></returns>
        public void getInput()
        {
            KreditBetrag = double.Parse(Form1.getKreditbetrag());
            Zinssatz = double.Parse(Form1.getZinssatz());
            Tilgungssatz = double.Parse(Form1.getTilgungssatz());
            Laufzeit = int.Parse(Form1.getLaufzeit());
            Date = Form1.getDate();
        }
    }
}
