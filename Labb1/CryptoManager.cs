using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Labb1
{
    internal class CryptoManager //Kryptan
    {
        private byte[] salt = new byte[16];

        public CryptoManager()
        {
            CreateSalt();
        }

        public byte[] GetSalt()
        {
            return salt;
        }
        public void CreateSalt()
        {
            // Generate a random salt
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
        }

        public string EncryptString(string plaintext, string password)
        {

            // Convert the plaintext string to a byte array
            byte[] plaintextBytes = System.Text.Encoding.UTF8.GetBytes(plaintext);

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
        public string DecryptString(string encrypted, string password, DatabaseConnection databaseConnection)
        {
            // Convert the encrypted string to a byte array
            byte[] encryptedBytes = Convert.FromBase64String(encrypted);

            // Derive the password using the PBKDF2 algorithm
            Rfc2898DeriveBytes passwordBytes = new Rfc2898DeriveBytes(password, databaseConnection.FetchSalt(encrypted), 1, HashAlgorithmName.SHA256);

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
