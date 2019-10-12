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
    public partial class AdaugareBeneficiarForm : Form
    {
        public string path = @"D:\Baza de date test";
        string path2= System.IO.Path.GetDirectoryName(Application.ExecutablePath)+ @"\Beneficiari\";
        SQLiteConnection sqlite = new SQLiteConnection("Data Source=D:\\Baza de date test\\Test.db");
        public AdaugareBeneficiarForm()
        {
            InitializeComponent();
        }

        private void adaugareButton_Click(object sender, EventArgs e)
        {
            if (sqlite.State!=ConnectionState.Open)
            {
                sqlite.Open();
                string insertQuery = "INSERT INTO Remoss(NrContract, DataContract, PFSC,Beneficiar,AdresaBeneficiar,RC,CIF,IBAN,Banca,Reprezentant,AdresaReprezentant,BICIReprezentant,CNPReprezentant,FunctieReprezentant,Mobil,An) VALUES(@NrContract, @DataContract, @PFSC,@Beneficiar,@AdresaBeneficiar,@RC,@CIF,@IBAN,@Banca,@Reprezentant,@AdresaReprezentant,@BICIReprezentant,@CNPReprezentant,@FunctieReprezentant,@Mobil,@An); ";
                SQLiteCommand command = new SQLiteCommand(insertQuery, sqlite);
                command.Parameters.AddWithValue("@NrContract", nrContractBox.Text.ToString());
                command.Parameters.AddWithValue("@DataContract", dateTimePicker1.Text.ToString());
                //if (pfRadioButton.Checked)
                //{
                //    command.Parameters.AddWithValue("@PFSC", "PF");
                //}
               
                //if (scRadioButton.Checked)
                //{
                //    command.Parameters.AddWithValue("@PFSC", "SC");
                //}

                command.Parameters.AddWithValue("@PFSC", "SC");

                command.Parameters.AddWithValue("@Beneficiar", beneficiarBox.Text.ToString());
                command.Parameters.AddWithValue("@AdresaBeneficiar", adresaBox.Text.ToString());
                command.Parameters.AddWithValue("@RC", rcBox.Text.ToString());
                command.Parameters.AddWithValue("@CIF", ibanBox.Text.ToString());
                command.Parameters.AddWithValue("@IBAN", ibanBox.Text.ToString());
                command.Parameters.AddWithValue("@Banca", bancaBox.Text.ToString());
                command.Parameters.AddWithValue("@Reprezentant", reprezentantBox.Text.ToString());
                command.Parameters.AddWithValue("@AdresaReprezentant", adresaReprezentantBox.Text.ToString());
                command.Parameters.AddWithValue("@BICIReprezentant", bciciReprezentant.Text.ToString());
                command.Parameters.AddWithValue("@CNPReprezentant", cnpReprBox.Text.ToString());
                command.Parameters.AddWithValue("@FunctieReprezentant", functiaReprezentantBox.Text.ToString());
                command.Parameters.AddWithValue("@Mobil", mobilBox.Text.ToString());
                command.Parameters.AddWithValue("@An", anBox.Text.ToString());
               
                command.ExecuteNonQuery();

                System.IO.Directory.CreateDirectory(path2+beneficiarBox.Text.ToString());
                System.IO.Directory.CreateDirectory(path2 + beneficiarBox.Text.ToString() + @"\01 Contracte");
                System.IO.Directory.CreateDirectory(path2 + beneficiarBox.Text.ToString() + @"\02 Primite");
                System.IO.Directory.CreateDirectory(path2 + beneficiarBox.Text.ToString() + @"\03 DRDP");
            }
        }

        private void cautarebutton_Click(object sender, EventArgs e)
        {
            RemossForm remos = new RemossForm();
            remos.Show();
        }
    }
}
