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
       
        SQLiteConnection sqlite=new SQLiteConnection("Data Source=" + System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\Test.db");

        DataTable dtbl=new DataTable();
        AdaugareBeneficiarForm adaugare;
        public RemossForm(AdaugareBeneficiarForm adaugareBeneficiarForm)
        {
            InitializeComponent();
            adaugareFiltruBox();
            populareTabela();
            adaugare = adaugareBeneficiarForm;
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int linia_selectata = dataGridView1.CurrentCell.RowIndex;
            adaugare.primireDate(
                dataGridView1.Rows[linia_selectata].Cells[0].Value.ToString(), 
                dataGridView1.Rows[linia_selectata].Cells[1].Value.ToString(),
                dataGridView1.Rows[linia_selectata].Cells[2].Value.ToString(),
                dataGridView1.Rows[linia_selectata].Cells[3].Value.ToString(),
                dataGridView1.Rows[linia_selectata].Cells[4].Value.ToString(),
                dataGridView1.Rows[linia_selectata].Cells[5].Value.ToString(),
                dataGridView1.Rows[linia_selectata].Cells[6].Value.ToString(), 
                dataGridView1.Rows[linia_selectata].Cells[7].Value.ToString(),
                dataGridView1.Rows[linia_selectata].Cells[8].Value.ToString(),
                dataGridView1.Rows[linia_selectata].Cells[9].Value.ToString(),
                dataGridView1.Rows[linia_selectata].Cells[10].Value.ToString(), 
                dataGridView1.Rows[linia_selectata].Cells[11].Value.ToString(), 
                dataGridView1.Rows[linia_selectata].Cells[12].Value.ToString(),
                dataGridView1.Rows[linia_selectata].Cells[13].Value.ToString(),
                dataGridView1.Rows[linia_selectata].Cells[14].Value.ToString(),
                dataGridView1.Rows[linia_selectata].Cells[15].Value.ToString(),
                dataGridView1.Rows[linia_selectata].Cells[16].Value.ToString());
            this.Close();
        }
      
    }
}
