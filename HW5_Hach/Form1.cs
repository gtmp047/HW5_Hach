using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW5_Hach
{
    public partial class Form1 : Form
    {
        byte mode = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Автор - Бурыгин Антон");
        }

        private void radiobutton1_CheckedChanged(object sender, EventArgs e)
        {
            mode = 0;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            mode = 1;
        }
    }
}
