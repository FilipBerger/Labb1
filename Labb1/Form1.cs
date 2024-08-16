using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Labb1
{
    public partial class Form1 : Form
    {    
        DatabaseConnection databaseConnection = new DatabaseConnection();
        CryptoManager cryptoManager = new CryptoManager();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            // Encrypt the input string and save it to the database
            string encrypted = cryptoManager.EncryptString(txtInput.Text, txtPassword.Text);
            txtOutput.Text = encrypted;
            databaseConnection.SaveEncryptedString(encrypted, cryptoManager.GetSalt());
            ClearInputs();
        }

        private void ClearInputs()
        {
            txtInput.Text = "";
            txtPassword.Text = "";
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            // Decrypt the input string and display it in the output textbox
            txtOutput.Text = "";

            try
            {
                string decrypted = cryptoManager.DecryptString(txtInput.Text, txtPassword.Text, databaseConnection);
                txtOutput.Text = decrypted;
            }
            catch (CryptographicException)
            {
                MessageBox.Show("Decryption failed. Invalid password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ClearInputs();
        }
    }
}
