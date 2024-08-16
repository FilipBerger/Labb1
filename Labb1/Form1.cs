using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Labb1
{
    public partial class Form1 : Form
    {
        //private byte[] salt = new byte[16];
        DatabaseConnection databaseConnection = new DatabaseConnection();

        public Form1()
        {
            InitializeComponent();
            
            //try
            //{
            //    cnn.Open();
            //    MessageBox.Show("Successful database connection!");
            //    cnn.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Unable to connect to database!");
            //}
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string password = txtPassword.Text;
            string plaintext = txtInput.Text;
            string encrypted = EncryptString(plaintext, password);
            txtOutput.Text = encrypted;
            SaveEncryptedString(encrypted);
            ClearInputs();
        }



        private void ClearInputs()
        {
            txtInput.Text = "";
            txtPassword.Text = "";
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string password = txtPassword.Text;
            string ciphertext = txtInput.Text;
            txtOutput.Text = "";

            try
            {
                string decrypted = DecryptString(ciphertext, password);
                txtOutput.Text = decrypted;
            }
            catch (CryptographicException)
            {
                MessageBox.Show("Decryption failed. Invalid password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ClearInputs();
        }

        string EncryptString(string plaintext, string password)
        {
            // Convert the plaintext string to a byte array
            byte[] plaintextBytes = System.Text.Encoding.UTF8.GetBytes(plaintext);

            // Generate a random salt
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            // Derive a new password using the PBKDF2 algorithm and a random salt
            Rfc2898DeriveBytes passwordBytes = new Rfc2898DeriveBytes(password, salt, 1, HashAlgorithmName.SHA256);

            // Use the password to encrypt the plaintext
            Aes encryptor = Aes.Create();
            encryptor.Key = passwordBytes.GetBytes(32);
            encryptor.IV = passwordBytes.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {

                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(plaintextBytes, 0, plaintextBytes.Length);
                }
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        string DecryptString(string encrypted, string password)
        {
            // Convert the encrypted string to a byte array
            byte[] encryptedBytes = Convert.FromBase64String(encrypted);

            // Derive the password using the PBKDF2 algorithm
            Rfc2898DeriveBytes passwordBytes = new Rfc2898DeriveBytes(password, salt, 1, HashAlgorithmName.SHA256);

            // Use the password to decrypt the encrypted string
            Aes encryptor = Aes.Create();
            encryptor.Key = passwordBytes.GetBytes(32);
            encryptor.IV = passwordBytes.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(encryptedBytes, 0, encryptedBytes.Length);
                }
                return System.Text.Encoding.UTF8.GetString(ms.ToArray());
            }
        }
    }
}
