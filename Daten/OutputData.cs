using System;

namespace Calc.Daten
{
    public class OutputData
    {
        MyForm form1;
        public OutputData() { }
        public OutputData(MyForm form1)
        {
            this.form1 = form1; //this ist immer ein Bezug auf die Klasse
        }
        public double Kreditbetrag { get; set; }
        public double Zinsen { get; set; }
        public double Tilgung { get; set; }
        public double Annuitaet { get; set; }
        public double Restbetrag { get; set; }
        public DateTime Date { get; set; }
       
        /// <summary>
        /// Hier erfolgt die Ausgabe in das Formular
        /// </summary>
        /// <param name="data"></param>
        public void setOutput(OutputData[] value)
        { /// 
            form1.getDGV().RowCount = value.Length;
            for (int i = 0; i < value.Length; i++)
            {
                form1.getDGV().Rows[0].Cells[0].Value = value[i].Date.Year;
                form1.getDGV().Rows[i].Cells[1].Value = value[i].Date.Month;
                form1.getDGV().Rows[i].Cells[2].Value = value[i].Kreditbetrag.ToString("#.00");
                form1.getDGV().Rows[i].Cells[3].Value = value[i].Zinsen.ToString("#.00");
                form1.getDGV().Rows[i].Cells[4].Value = value[i].Tilgung.ToString("#.00");
                form1.getDGV().Rows[i].Cells[5].Value = value[i].Annuitaet.ToString("#.00");
                form1.getDGV().Rows[i].Cells[6].Value = value[i].Restbetrag.ToString("#.00");
                if (i > 11)
                {
                    form1.getDGV().Rows[i].Cells[0].Value = value[i].Date.Year;
                    form1.getDGV().Rows[i].Cells[1].Value = value[12].Date.Month; // hier dann der fixe Monat aus dem DateTime-Picker
                    form1.getDGV().Rows[i].Cells[2].Value = value[i].Kreditbetrag.ToString("#.00");
                    form1.getDGV().Rows[i].Cells[3].Value = value[i].Zinsen.ToString("#.00");
                    form1.getDGV().Rows[i].Cells[4].Value = value[i].Tilgung.ToString("#.00");
                    form1.getDGV().Rows[i].Cells[5].Value = value[i].Annuitaet.ToString("#.00");
                    form1.getDGV().Rows[i].Cells[6].Value = value[i].Restbetrag.ToString("#.00");
                }
            }
        }
    }
}
