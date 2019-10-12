using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evidenta3
{
    public partial class RemossForm : Form
    {
        public string path = @"D:\Baza de date test";
        SQLiteConnection sqlite=new SQLiteConnection("Data Source=D:\\Baza de date test\\Test.db");
        DataTable dtbl=new DataTable();
        public RemossForm()
        {
            InitializeComponent();
            adaugareFiltruBox();
            populareTabela();
        }
        //populare combobox
        public void adaugareFiltruBox()
        {
            List<String> filtre = new List<string>();
            filtre.Add("Beneficiar");
            filtre.Add("NrConract");
            filtre.Add("An");
            filtruBox.DataSource = filtre;
        }
        public void populareTabela()
        {
            string selectString="Select * from Remoss";
            SQLiteCommand cmd = new SQLiteCommand(selectString, sqlite);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            da.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
        }

        private void cautareBox_TextChanged(object sender, EventArgs e)
        {
            string filtru_selectat = filtruBox.SelectedItem.ToString();
            string cuvant_cautat = cautareBox.Text.ToString();
            string selectString = "Select * from Remoss WHERE "+ filtru_selectat+" LIKE '%"+cuvant_cautat+"%'";
            SQLiteCommand cmd = new SQLiteCommand(selectString, sqlite);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);

            dtbl = new DataTable();
                da.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
           
           
        }

        private void adaugaButton_Click(object sender, EventArgs e)
        {

        }
    }
}
