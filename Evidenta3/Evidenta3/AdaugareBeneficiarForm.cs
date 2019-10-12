using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evidenta3
{
    public partial class AdaugareBeneficiarForm : Form
    {
        string nr_curent;  
        string path2= System.IO.Path.GetDirectoryName(Application.ExecutablePath)+ @"\Beneficiari\";
        SQLiteConnection sqlite = new SQLiteConnection("Data Source="+ System.IO.Path.GetDirectoryName(Application.ExecutablePath)+@"\Test.db");
        public AdaugareBeneficiarForm()
        {
            InitializeComponent();
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void adaugareButton_Click(object sender, EventArgs e)
        {
            if (sqlite.State != ConnectionState.Open)
            {
                sqlite.Open();
            }
                string insertQuery = "INSERT INTO Remoss(NrContract, DataContract, PFSC,Beneficiar,AdresaBeneficiar,RC,CIF,IBAN,Banca,Reprezentant,AdresaReprezentant,BICIReprezentant,CNPReprezentant,FunctieReprezentant,Mobil,An) VALUES(@NrContract, @DataContract, @PFSC,@Beneficiar,@AdresaBeneficiar,@RC,@CIF,@IBAN,@Banca,@Reprezentant,@AdresaReprezentant,@BICIReprezentant,@CNPReprezentant,@FunctieReprezentant,@Mobil,@An); ";
                SQLiteCommand command = new SQLiteCommand(insertQuery, sqlite);
                command.Parameters.AddWithValue("@NrContract", nrContractBox.Text.ToString());
                command.Parameters.AddWithValue("@DataContract", dateTimePicker1.Text.ToString());
                if (pfRadioButton.Checked)
                {
                    command.Parameters.AddWithValue("@PFSC", "PF");
                }
                if(scRadioButton.Checked){
                    command.Parameters.AddWithValue("@PFSC", "SC");
                }
                command.Parameters.AddWithValue("@Beneficiar", beneficiarBox.Text.ToString());
                command.Parameters.AddWithValue("@AdresaBeneficiar", adresaBox.Text.ToString());
                command.Parameters.AddWithValue("@RC", rcBox.Text.ToString());
                command.Parameters.AddWithValue("@CIF", cifcuiBox.Text.ToString());
                command.Parameters.AddWithValue("@IBAN", ibanBox.Text.ToString());
                command.Parameters.AddWithValue("@Banca", bancaBox.Text.ToString());
                command.Parameters.AddWithValue("@Reprezentant", reprezentantBox.Text.ToString());
                command.Parameters.AddWithValue("@AdresaReprezentant", adresaReprezentantBox.Text.ToString());
                command.Parameters.AddWithValue("@BICIReprezentant", bciciReprezentant.Text.ToString());
                command.Parameters.AddWithValue("@CNPReprezentant", cnpReprBox.Text.ToString());
                command.Parameters.AddWithValue("@FunctieReprezentant", functiaReprezentantBox.Text.ToString());
                command.Parameters.AddWithValue("@Mobil", mobilBox.Text.ToString());
                command.Parameters.AddWithValue("@An", anBox.Text.ToString());

                try
                {
                    command.ExecuteNonQuery();
                System.IO.Directory.CreateDirectory(path2+beneficiarBox.Text.ToString());
                System.IO.Directory.CreateDirectory(path2 + beneficiarBox.Text.ToString() + @"\01 Contracte");
                System.IO.Directory.CreateDirectory(path2 + beneficiarBox.Text.ToString() + @"\02 Primite");
                System.IO.Directory.CreateDirectory(path2 + beneficiarBox.Text.ToString() + @"\03 DRDP");
                MessageBox.Show("Contract adaugat");
                    
                }
                catch (Exception )
                {
                    
                    MessageBox.Show("Selectati optiunea de PF sau SC");
        

            }
        }

        private void cautarebutton_Click(object sender, EventArgs e)
        {
            RemossForm remos = new RemossForm(this);
            remos.Show();
        }
        public void primireDate(string an,string nrCurent,string nrCon, string dataCon, string psfc, string benef, string adrben, string rc, string cif, string iban, string banca, string repr, string adrep, string bici, string cnprep, string fctrep, string mob)
        {
            nr_curent = nrCurent;
            DateTime date= DateTime.ParseExact(dataCon, "dd/MM/yyyy", null);
            dateTimePicker1.Value = date; 
            nrContractBox.Text = nrCon;
            beneficiarBox.Text = benef;
            adresaBox.Text = adrben;
            rcBox.Text = rc;
            cifcuiBox.Text = cif;
            ibanBox.Text = iban;
            bancaBox.Text = banca;
            reprezentantBox.Text = repr;
            adresaReprezentantBox.Text = adrep;
            bciciReprezentant.Text = bici;
            cnpReprBox.Text = cnprep;
            functiaReprezentantBox.Text = fctrep;
            mobilBox.Text = mob;
            anBox.Text = an;
            modificareButton.Enabled = true;
            if (psfc.Equals("PF"))
            {
                pfRadioButton.Checked = true;
            }
            else
            {
                scRadioButton.Checked = true;
            }
        }

        private void modificareButton_Click(object sender, EventArgs e)
        {
            if (sqlite.State != ConnectionState.Open)
                sqlite.Open();
            string updateQuery = "UPDATE Remoss SET " +
                "NrContract = @NrContract, " +
                "DataContract = @DataContract," +
                " PFSC = @PFSC ," +
                " Beneficiar = @Beneficiar," +
                " AdresaBeneficiar = @AdresaBeneficiar," +
                " RC = @RC, " +
                "CIF = @CIF," +
                " IBAN = @IBAN," +
                " Banca = @Banca, " +
                "Reprezentant = @Reprezentant," +
                " BICIReprezentant = @BICIReprezentant," +
                " CNPReprezentant = @CNPReprezentant," +
                " FunctieReprezentant = @FunctieReprezentant," +
                " Mobil = @Mobil, " +
                "An = @An," +
                " AdresaBeneficiar = @AdresaBeneficiar " +

                "WHERE NrCurent = " + nr_curent;
            SQLiteCommand command = new SQLiteCommand(updateQuery, sqlite);
            command.Parameters.AddWithValue("@NrContract", nrContractBox.Text.ToString());
            command.Parameters.AddWithValue("@DataContract", dateTimePicker1.Text.ToString());
            if (pfRadioButton.Checked)
            {
                command.Parameters.AddWithValue("@PFSC", "PF");
            }
            if (scRadioButton.Checked)
            {
                command.Parameters.AddWithValue("@PFSC", "SC");
            }
            command.Parameters.AddWithValue("@Beneficiar", beneficiarBox.Text.ToString());
            command.Parameters.AddWithValue("@AdresaBeneficiar", adresaBox.Text.ToString());
            command.Parameters.AddWithValue("@RC", rcBox.Text.ToString());
            command.Parameters.AddWithValue("@CIF", cifcuiBox.Text.ToString());
            command.Parameters.AddWithValue("@IBAN", ibanBox.Text.ToString());
            command.Parameters.AddWithValue("@Banca", bancaBox.Text.ToString());
            command.Parameters.AddWithValue("@Reprezentant", reprezentantBox.Text.ToString());
            command.Parameters.AddWithValue("@AdresaReprezentant", adresaReprezentantBox.Text.ToString());
            command.Parameters.AddWithValue("@BICIReprezentant", bciciReprezentant.Text.ToString());
            command.Parameters.AddWithValue("@CNPReprezentant", cnpReprBox.Text.ToString());
            command.Parameters.AddWithValue("@FunctieReprezentant", functiaReprezentantBox.Text.ToString());
            command.Parameters.AddWithValue("@Mobil", mobilBox.Text.ToString());
            command.Parameters.AddWithValue("@An", anBox.Text.ToString());
            // command.Parameters.AddWithValue("@nrTelefon", phoneBox.Text);

            command.ExecuteNonQuery();
            MessageBox.Show("Datele beneficiarului au fost modificate");
        }
    }
}
