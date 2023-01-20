using System.Text;
using System.Security.Cryptography;

namespace Encryption_Decryption {
    public class Decryption {
        /// <summany>
        /// StartDecrypt method decrypts text
        /// </summary>
        public void StartDecrypt() {
            // Hash
            Console.Write("Please enter hash (hash can be what do you want): ");
            string hash = Convert.ToString(Console.ReadLine());

            // Text
            Console.Write("Enter the text you want to decrypt: ");
            string text = Convert.ToString(Console.ReadLine());

            // Decryption
            byte[] data = Convert.FromBase64String(text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider()) {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 }) {
                    ICryptoTransform iCryptoTrans = tripleDES.CreateDecryptor();
                    byte[] result = iCryptoTrans.TransformFinalBlock(data, 0, data.Length);
                    string decryptedText = UTF8Encoding.UTF8.GetString(result);
                    Console.WriteLine("Decrypted Text: " + decryptedText);
                }
            }
        }
    }
}