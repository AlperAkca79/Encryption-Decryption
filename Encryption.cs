using System.Text;
using System.Security.Cryptography;

namespace Encryption_Decryption {
    public class Encryption {
        /// <summany>
        /// StartEncrypt method encrypts text
        /// </summary>
        public void StartEncrypt() {
            // Hash
            Console.Write("Please enter hash (hash can be what do you want): ");
            string hash = Convert.ToString(Console.ReadLine());

            // Text
            Console.Write("Enter the text you want to encrypt: ");
            string text = Convert.ToString(Console.ReadLine());

            // Encryption
            byte[] data = UTF8Encoding.UTF8.GetBytes(text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider()) {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 }) {
                    ICryptoTransform iCryptoTrans = tripleDES.CreateEncryptor();
                    byte[] result = iCryptoTrans.TransformFinalBlock(data, 0, data.Length);
                    string encryptedText = Convert.ToBase64String(result, 0, result.Length);
                    Console.WriteLine("Encrypted Text: " + encryptedText);
                }
            }
        }
    }
}