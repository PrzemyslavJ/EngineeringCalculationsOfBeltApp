using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MechStudio
{
    public partial class Opissilnika : Form
    {
        public Opissilnika()
        {
            InitializeComponent();
        }

        public int select { get; set; } = 0;

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked) { select = 1; }
            else if (radioButton2.Checked) { select = 2; }
            else if (radioButton3.Checked) { select = 3; }
            else if (radioButton4.Checked) { select = 4; }

            Close();
            
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
