using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evidenta3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void remossButton_Click(object sender, EventArgs e)
        {
            AdaugareBeneficiarForm remos = new AdaugareBeneficiarForm();
            remos.Show();
            this.Hide();
        }

        private void rmsroadButton_Click(object sender, EventArgs e)
        {

        }
    }
}
