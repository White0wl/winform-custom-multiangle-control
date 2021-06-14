using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            userControl11.Sides = Decimal.ToInt32(numericUpDown1.Value);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            userControl11.Radius = Decimal.ToInt32(numericUpDown2.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if(dlg.ShowDialog()== DialogResult.OK)
            {
                userControl11.FillColor = dlg.Color;
                buttonFill.BackColor = dlg.Color;
                checkBoxFillVis.Checked = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                userControl11.BorderColor = dlg.Color;
                buttonBorder.BackColor = dlg.Color;
                checkBoxBorderVis.Checked = true;
            }
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            userControl11.Angle = Decimal.ToInt32(numericUpDown3.Value);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            userControl11.ShowRadius = checkBoxRadiusVis.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            userControl11.ShowFill = checkBoxFillVis.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            userControl11.ShowBorder = checkBoxBorderVis.Checked;
        }
    }
}
