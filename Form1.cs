using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc
{
    public partial class MyForm : System.Windows.Forms.Form
    {
        private InputData Input;
        private OutputData Output;
        public MyForm()
        {
            InitializeComponent();
            Input = new InputData(this); //Mit "this" referenzieren wir auf die Klasse selbst, also auf das Objekt der Klasse MyForm
            Output = new OutputData(this);
        }

        private void buttonCalc_Click(object sender, EventArgs e)
        {
            // 1. Daten aus Formular auslesen
            Input.getInput();
            // 2. Daten validieren (Wertebereich)
            if (Input.CheckData() == true)
            {
                Annuitaet annuitaet = new Annuitaet(Input);
                annuitaet.Input = Input;
                // 3. Berechnung durchführen
                OutputData[] outputData = annuitaet.BerechneDarlehen();
                // 4. Daten an Formular ausgeben
                Output.setOutput(outputData);
            }
        }
        public string getKreditbetrag()
        {
            return textBoxKreditbetrag.Text;
        }
        public string getZinssatz()
        {
            return textBoxZinsatz.Text;
        }
        public string getTilgungssatz()
        {
            return textBoxTilgungssatz.Text;
        }
        public string getLaufzeit()
        {
            return textBoxLaufzeit.Text;
        }
        public DateTime getDate()
        {
            return dateTimePicker.Value;
        }
        public DataGridView getDGV()
        {
            return dataGridView;
        }
    }
}